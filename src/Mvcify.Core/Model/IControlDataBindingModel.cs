using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mvcify.Core.Model
{
    public interface IControlDataBindingModel<TModel> //: INotifyPropertyChanged
    {
        TModel Model { get; set; }
        bool IsUpdating { get; set; }
        PropertyInfo PropertyInfo { get; set; }
        Action SetModelPropertyValue { get; set; }
        bool HasSetModelPropertyValue { get; }
        Action SetControlPropertyValue { get; set; }
        bool HasSetControlPropertyValue { get; }
        Action BindDataSourceFunction { get; set; }
        bool HasBindDataSourceFunction { get; }
        Action<TModel> ChangedAction { get; set; }
        bool HasChangedAction { get; }

        Action<TModel> ValidateSuccessAction { get; set; }
        bool HasValidateSuccessAction { get; }
        Action<TModel> ValidateFailedAction { get; set; }
        bool HasValidateFailedAction { get; }
        Action<TModel, Exception> ValidateFailedWithExceptionAction { get; set; }
        bool HasValidateFailedWithExceptionAction { get; }
        Exception ValidateException { get; set; }
        bool HasValidateException { get; }
        Func<TModel, bool> ValidateExpressionFunction { get; set; }
        bool HasValidateExpressionFunction { get; }
    }
}
