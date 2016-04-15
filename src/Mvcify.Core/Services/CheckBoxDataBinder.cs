using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Model;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services
{
    public class CheckBoxDataBinder : IDataBinder<CheckBox> 
    {
        private readonly ILog _log;

        public CheckBoxDataBinder(ILog log)
        {
            _log = log;
            _log.Debug("ctor");
        }

        public void BindControlEvents<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug("BindControlEvents");
            controlDataBindingModel.Control.CheckedChanged +=
                delegate { controlDataBindingModel.SetModelPropertyValue(); };
        }

        public Action SetModelPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug("SetModelPropertyValue");
            return
                delegate
                {
                    controlDataBindingModel.PropertyInfo.SetValue(controlDataBindingModel.Model,
                        controlDataBindingModel.Control.Checked);
                };
        }

        public Action SetControlPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug("SetControlPropertyValue");
            return
                delegate
                {
                    controlDataBindingModel.Control.Checked =
                        (bool)controlDataBindingModel.PropertyInfo.GetValue(controlDataBindingModel.Model);
                };
        }

        public void BindDataSource<TModel, TCollection, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged where TCollection : ICollection
        {
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
//    public class CheckBoxDataBinder<TModel> : IDataBinder<TModel, CheckBox> where TModel : class, INotifyPropertyChanged
//    {
//        private readonly ReflectionHelper _reflectionHelper;
//        private BindingModel<TModel> _bindingModel;

//        public CheckBoxDataBinder(ReflectionHelper reflectionHelper)
//        {
//            _reflectionHelper = reflectionHelper;
//        }

//        public void Bind(TextBox control, TModel model, Expression<Func<TModel, bool>> expression)
//        {
//            var propertyInfo = _reflectionHelper.GetPropertyInfo(model, expression);
//            var ControlDataBindingModel = new ControlDataBindingModel<TModel, bool>
//            {
//                Control = control,
//                Expression = expression,
//                Function = expression.Compile(),
//                PropertyInfo = propertyInfo,
//                Model = model,
//                IsUpdating = false,
//            };
//            ControlDataBindingModel.SetModelPropertyValue = delegate
//            {
//                ControlDataBindingModel.PropertyInfo.SetValue(model, control.Text);
//            };
//            ControlDataBindingModel.SetControlPropertyValue = delegate
//            {
//                ControlDataBindingModel.Control.Text = ControlDataBindingModel.PropertyInfo.GetValue(model).ToString();
//            };

//            control.TextChanged += delegate {
//                ControlDataBindingModel.OnPropertyChanged(ControlDataBindingModel.PropertyInfo.Name);
//            };
//            _bindingModel.ControlDataBindings.Add(control, ControlDataBindingModel);
//        }


//        public void Initialize(BindingModel<TModel> bindingModel)
//        {
//            _bindingModel = bindingModel;
//        }

//        public IDataBinderValidator<TModel> Validate(Expression<Func<TModel, bool>> expression)
//        {
//            throw new NotImplementedException();
//        }

//        IDataBinder<TModel, CheckBox> IDataBinder<TModel, CheckBox>.DataSource(Expression<Func<TModel, List<string>>> expression)
//        {
//            throw new NotImplementedException();
//        }

//        IDataBinder<TModel, CheckBox> IDataBinder<TModel, CheckBox>.OnChanged(Action<TModel> action)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}