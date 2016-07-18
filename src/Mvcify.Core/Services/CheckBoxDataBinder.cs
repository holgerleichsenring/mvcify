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
            _log.Debug();
        }

        public void BindControlEvents<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            controlDataBindingModel.Control.CheckedChanged +=
                delegate { controlDataBindingModel.SetModelPropertyValue(); };
        }

        public Action SetModelPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            return
                delegate
                {
                    controlDataBindingModel.PropertyInfo.SetValue(controlDataBindingModel.Model,
                        controlDataBindingModel.Control.Checked);
                };
        }

        public Action SetControlPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, CheckBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
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

