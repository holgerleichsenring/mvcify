using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Model;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services
{
    public class CombobBoxDataBinder : IDataBinder<ComboBox>
    {
        private readonly ILog _log;

        public CombobBoxDataBinder(ILog log)
        {
            _log = log;
            _log.Debug();
        }

        public void BindControlEvents<TModel, TResult>(
            ControlDataBindingModel<TModel, ComboBox, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            controlDataBindingModel.Control.TextChanged +=
                delegate { controlDataBindingModel.SetModelPropertyValue(); };

        }

        public void BindDataSource<TModel, TCollection, TResult>(
            ControlDataBindingModel<TModel, ComboBox, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged where TCollection : ICollection
        {
            _log.Debug();
            var list =
                controlDataBindingModel.DataSourcePropertyInfo.GetValue(controlDataBindingModel.Model) as ICollection;
            foreach (var item in list)
            {
                controlDataBindingModel.Control.Items.Add(item);
            }
        }

        public Action SetModelPropertyValue<TModel, TResult>(
            ControlDataBindingModel<TModel, ComboBox, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            return
                delegate
                {
                    controlDataBindingModel.PropertyInfo.SetValue(controlDataBindingModel.Model,
                        controlDataBindingModel.Control.Text);
                };
        }

        public Action SetControlPropertyValue<TModel, TResult>(
            ControlDataBindingModel<TModel, ComboBox, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            return
                delegate
                {
                    controlDataBindingModel.Control.Text =
                        controlDataBindingModel.PropertyInfo.GetValue(controlDataBindingModel.Model).ToString();
                };
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Mvcify.Model;
//using Mvcify.Services.Interfaces;

//namespace Mvcify.Services
//{
//    public class ComboBoxDataBinder<TModel> : IDataBinder<TModel, ComboBox> where TModel : class, INotifyPropertyChanged
//    {
//        private readonly ReflectionHelper _reflectionHelper;
//        private BindingModel<TModel> _bindingModel;
//        private ControlDataBindingModel<TModel, object> _controlDataBindingModel;

//        public ComboBoxDataBinder(ReflectionHelper reflectionHelper)
//        {
//            _reflectionHelper = reflectionHelper;
//        }

//        public void Bind(TextBox control, TModel model, Expression<Func<TModel, object>> expression)
//        {
//            var propertyInfo = _reflectionHelper.GetPropertyInfo(model, expression);
//            _controlDataBindingModel = new ControlDataBindingModel<TModel, object>
//            {
//                Control = control,
//                Expression = expression,
//                Function = expression.Compile(),
//                PropertyInfo = propertyInfo,
//                Model = model,
//                IsUpdating = false,
//            };
//            _controlDataBindingModel.SetModelPropertyValue = delegate
//            {
//                _controlDataBindingModel.PropertyInfo.SetValue(model, control.Text);
//            };
//            _controlDataBindingModel.SetControlPropertyValue = delegate
//            {
//                _controlDataBindingModel.Control.Text = _controlDataBindingModel.PropertyInfo.GetValue(model).ToString();
//            };

//            control.TextChanged += delegate {
//                _controlDataBindingModel.OnPropertyChanged(_controlDataBindingModel.PropertyInfo.Name);
//            };
//            _bindingModel.ControlDataBindings.Add(control, _controlDataBindingModel);
//        }


//        public void Initialize(BindingModel<TModel> bindingModel)
//        {
//            _bindingModel = bindingModel;

//        }

//        private bool HasExpressionModel()
//        {
//            return _controlDataBindingModel != null;
//        }
//        public IDataBinder<TModel, ComboBox> DataSource(Expression<Func<TModel, List<string>>> expression)
//        {
//            if (!HasExpressionModel())
//            {
//                throw new Exception("Call Bind first");
//            }

//            _controlDataBindingModel.DataSourceExpression = expression;
//            _controlDataBindingModel.DataSourceFunction = expression.Compile();
//            return this;
//        }

//        public IDataBinder<TModel, ComboBox> OnChanged(Action<TModel> action)
//        {
//            if (!HasExpressionModel())
//            {
//                throw new Exception("Call Bind first");
//            }
//            return this;
//        }

//        public IDataBinderValidator<TModel> Validate(Expression<Func<TModel, bool>> expression)
//        {
//            if (!HasExpressionModel())
//            {
//                throw new Exception("Call Bind first");
//            }
//            return null;
//        }
//    }
//}