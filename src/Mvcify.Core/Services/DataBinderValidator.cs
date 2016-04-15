using System;
using System.ComponentModel;
using System.Windows.Forms;
using Mvcify.Core.Services.Interfaces;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services
{
    internal class DataBinderValidator<TModel, TControl, TResult> : IDataBinderValidator<TModel, TControl, TResult>
        where TModel : class, INotifyPropertyChanged where TControl : Control
    {
        private ControlDataBindingModel<TModel, TControl, TResult> _controlDataBindingModel;

        public void Initialize(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel)
        {
            _controlDataBindingModel = controlDataBindingModel;
        }

        public IDataBinderValidator<TModel, TControl, TResult> OnSuccess(Action<TModel> successAction)
        {
            _controlDataBindingModel.ValidateSuccessAction = successAction;
            return this;
        }

        public IDataBinderValidator<TModel, TControl, TResult> OnFailed(Action<TModel> failedAction)
        {
            _controlDataBindingModel.ValidateFailedAction = failedAction;
            return this;
        }
        public IDataBinderValidator<TModel, TControl, TResult> OnFailed(Action<TModel, Exception> failedAction)
        {
            _controlDataBindingModel.ValidateFailedWithExceptionAction = failedAction;
            return this;
        }
    }
}