using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using Mvcify.Core.Services.Interfaces;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services.Interfaces
{
    public interface IDataBinderProxy<TModel, TControl, TResult> where TControl : Control where TModel : class, INotifyPropertyChanged
    {
        void Initialize(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel, IDataBinder<TControl> dataBinder);
        IDataBinderProxy<TModel, TControl, TResult> DataSource<TCollection>(Expression<Func<TModel, TCollection>> expression)
            where TCollection : ICollection;
        IDataBinderProxy<TModel, TControl, TResult> DataSource<TData>(IDataSourceBinder<TControl, TData> dataSourceBinder, TData data) where TData: class;
        IDataBinderProxy<TModel, TControl, TResult> OnChanged(Action<TModel> action);
        IDataBinderValidator<TModel, TControl, TResult> Validate(Expression<Func<TModel, bool>> expression);
    }
}