using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Model;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services
{
    public class DataBinder<TModel> where TModel : class, INotifyPropertyChanged
    {
        private readonly BindingModel<TModel> _bindingModel;
        private readonly ILog _log;
        private readonly IObjectFactory _objectFactory;
        private readonly ReflectionHelper _reflectionHelper;

        public DataBinder(ILog log, IObjectFactory objectFactory, ReflectionHelper reflectionHelper)
        {
            _bindingModel = new BindingModel<TModel>();
            _log = log;
            _log.Debug();
            _objectFactory = objectFactory;
            _reflectionHelper = reflectionHelper;
        }

        public IDataBinderProxy<TModel, TControl, TResult> Bind<TControl, TResult>(TControl control, TModel model, Expression<Func<TModel, TResult>> expression) where TControl: Control
        {
            _log.Debug();
            var dataBinder = _objectFactory.Resolve<IDataBinder<TControl>>();

            ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel = CreateControlDataBindingModel(control, model, expression);
            dataBinder.BindControlEvents(controlDataBindingModel);
            controlDataBindingModel.SetControlPropertyValue = dataBinder.SetControlPropertyValue(controlDataBindingModel);
            controlDataBindingModel.SetModelPropertyValue = dataBinder.SetModelPropertyValue(controlDataBindingModel);
            _bindingModel.ControlDataBindings.Add(control, controlDataBindingModel);

            var dataBinderProxy = _objectFactory.Resolve<IDataBinderProxy<TModel, TControl, TResult>>();
            dataBinderProxy.Initialize(controlDataBindingModel, dataBinder);
            return dataBinderProxy;
        }

        private ControlDataBindingModel<TModel, TControl, TResult> CreateControlDataBindingModel<TControl, TResult>(TControl control, TModel model, Expression<Func<TModel, TResult>> expression) where TControl: Control
        {
            _log.Debug();
            var propertyInfo = _reflectionHelper.GetPropertyInfo(model, expression);
            return new ControlDataBindingModel<TModel, TControl, TResult>
            {
                Control = control,
                Expression = expression,
                Function = expression.Compile(),
                PropertyInfo = propertyInfo,
                Model = model,
                IsUpdating = false,
            };
        }
        public void Bind(TModel model)
        {
            _log.Debug();
            var controlExpressions = _bindingModel.ControlDataBindings;

            model.PropertyChanged += (sender, args) =>
            {
                var controlDataBindingModel = controlExpressions.Values.FirstOrDefault(controlExpressionModelLoop =>
                    controlExpressionModelLoop.PropertyInfo.Name == args.PropertyName);

                if (controlDataBindingModel == null)
                {
                    return;
                }

                if (!controlDataBindingModel.IsUpdating)
                {
                    controlDataBindingModel.IsUpdating = true;
                    try
                    {
                        controlDataBindingModel.SetControlPropertyValue();
                    }
                    finally
                    {
                        controlDataBindingModel.IsUpdating = false;
                    }
                }
            };
            foreach (var controlDataBindingModel in _bindingModel.ControlDataBindings.Values)
            {
                controlDataBindingModel.Model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
                {
                    if (args.PropertyName == controlDataBindingModel.PropertyInfo.Name && !controlDataBindingModel.IsUpdating)
                    {
                        controlDataBindingModel.IsUpdating = true;
                        try
                        {
                            controlDataBindingModel.SetModelPropertyValue();
                        }
                        finally
                        {
                            controlDataBindingModel.IsUpdating = false;
                        }
                    }
                };

                if (controlDataBindingModel.HasChangedAction)
                {
                    controlDataBindingModel.Model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
                    {
                        if (args.PropertyName != controlDataBindingModel.PropertyInfo.Name)
                        {
                            return;
                        }
                        controlDataBindingModel.ChangedAction(controlDataBindingModel.Model);
                    };
                }

                if (controlDataBindingModel.HasValidateExpressionFunction)
                {
                    controlDataBindingModel.Model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
                    {
                        if (args.PropertyName != controlDataBindingModel.PropertyInfo.Name)
                        {
                            return;
                        }
                        try
                        {
                            controlDataBindingModel.ValidateException = null;
                            if (controlDataBindingModel.ValidateExpressionFunction(controlDataBindingModel.Model))
                            {
                                controlDataBindingModel.ValidateSuccessAction(controlDataBindingModel.Model);
                                return;
                            }

                            if (controlDataBindingModel.HasValidateFailedAction)
                            {
                                controlDataBindingModel.ValidateFailedAction(controlDataBindingModel.Model);
                                return;
                            }
                            _log.WarnFormat("Validation failed without raising exception. There is no validate failed action defined for property {0}. ", args.PropertyName);
                        }
                        catch (Exception ex)
                        {
                            _log.ErrorFormat("Validation failed with exception for property {0}", args.PropertyName);
                            controlDataBindingModel.ValidateException = ex;
                            if (controlDataBindingModel.HasValidateFailedWithExceptionAction)
                            {
                                controlDataBindingModel.ValidateFailedWithExceptionAction(controlDataBindingModel.Model, ex);
                                return;
                            }
                            _log.WarnFormat("Validation failed with raising an exception. There is no validate failed action defined for property {0}. ", args.PropertyName);
                        }

                    };
                }
                controlDataBindingModel.IsUpdating = true;
                try
                {
                    if (controlDataBindingModel.HasBindDataSourceFunction)
                    {
                        controlDataBindingModel.BindDataSourceFunction();
                    }
                    // set initial value
                    controlDataBindingModel.SetControlPropertyValue();
                }
                finally
                {
                    controlDataBindingModel.IsUpdating = false;
                }
            }
        }
    }
}