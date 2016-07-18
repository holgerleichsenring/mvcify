using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using Mvcify.Common.Services.Interfaces;
using Mvcify.Core.Model;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services
{   
    public class TextBoxDataBinder : IDataBinder<TextBox>
    {
        private readonly ILog _log;

        public TextBoxDataBinder(ILog log)
        {
            _log = log;
            _log.Debug();
        }

        public void BindControlEvents<TModel, TResult>(ControlDataBindingModel<TModel, TextBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            controlDataBindingModel.Control.TextChanged +=
                delegate { controlDataBindingModel.SetModelPropertyValue(); };
        }

        public void BindDataSource<TModel, TCollection, TResult>(ControlDataBindingModel<TModel, TextBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged where TCollection : ICollection
        {
        }

        public Action SetModelPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, TextBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
        {
            _log.Debug();
            return
                delegate
                {
                    controlDataBindingModel.PropertyInfo.SetValue(controlDataBindingModel.Model,
                        controlDataBindingModel.Control.Text);
                };
        }


        public Action SetControlPropertyValue<TModel, TResult>(ControlDataBindingModel<TModel, TextBox, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged
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