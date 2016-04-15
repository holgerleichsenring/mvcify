using System;
using System.Windows.Forms;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services.Interfaces
{
    public interface IDataBinderValidator<TModel, TControl, TResult> where TModel: class where TControl : Control
    {
        void Initialize(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel);

        IDataBinderValidator<TModel, TControl, TResult> OnSuccess(Action<TModel> successAction);
        IDataBinderValidator<TModel, TControl, TResult> OnFailed(Action<TModel> failedAction);
        IDataBinderValidator<TModel, TControl, TResult> OnFailed(Action<TModel, Exception> failedAction);
    }
}
