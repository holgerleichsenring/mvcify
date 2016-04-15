using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Mvcify.Annotations;
using Mvcify.Common.Services.Interfaces;

namespace Mvcify.Core.Model
{
    public class ControlDataBindingModel<TModel, TControl, TResult> : IControlDataBindingModel<TModel> where TControl : Control
    {
        public Expression<Func<TModel, TResult>> Expression { get; set; }
        public Func<TModel, TResult> Function { get; set; }

        public TModel Model { get; set; }
        public TControl Control { get; set; }

        public bool IsUpdating { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public Action SetModelPropertyValue { get; set; }
        public bool HasSetModelPropertyValue => SetModelPropertyValue != null;
        public Action SetControlPropertyValue { get; set; }
        public bool HasSetControlPropertyValue => SetControlPropertyValue != null;

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public Expression<Func<TModel, ICollection>> DataSourceExpression { get; set; }
        public Func<TModel, ICollection> DataSourceFunction { get; set; }
        public Action<TModel> ChangedAction { get; set; }
        public bool HasChangedAction => ChangedAction != null;
        public Expression<Func<TModel, bool>> ValidateExpression { get; set; }
        public Func<TModel, bool> ValidateExpressionFunction { get; set; }
        public bool HasValidateExpressionFunction => ValidateExpressionFunction != null;
        public Action<TModel> ValidateSuccessAction { get; set; }
        public bool HasValidateSuccessAction => ValidateSuccessAction != null;
        public Action<TModel> ValidateFailedAction { get; set; }
        public bool HasValidateFailedAction => ValidateFailedAction != null;
        public Action<TModel, Exception> ValidateFailedWithExceptionAction { get; set; }
        public bool HasValidateFailedWithExceptionAction => ValidateFailedWithExceptionAction != null;
        public PropertyInfo DataSourcePropertyInfo { get; set; }
        public Action BindDataSourceFunction { get; set; }
        public bool HasBindDataSourceFunction => BindDataSourceFunction != null;
        public Exception ValidateException { get; set; }
        public bool HasValidateException => ValidateException != null;
    }

}