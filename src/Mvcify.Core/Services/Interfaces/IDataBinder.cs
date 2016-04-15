using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services.Interfaces
{
    public interface IDataBinder<TControl> where TControl : Control
    {
        //void Initialize(BindingModel<TModel> bindingModel);
        //void Bind(TControl control, TModel model, Expression<Func<TModel, TResult>> expression);
        void BindControlEvents<TModel, TResult>(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged;
        void BindDataSource<TModel, TCollection, TResult>(ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel)
            where TModel : class, INotifyPropertyChanged where TCollection : ICollection;

        Action SetModelPropertyValue<TModel, TResult>(
            ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged;

        Action SetControlPropertyValue<TModel, TResult>(
            ControlDataBindingModel<TModel, TControl, TResult> controlDataBindingModel) where TModel : class, INotifyPropertyChanged;


    }
}