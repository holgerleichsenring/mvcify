using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Mvcify.Core.Model;

namespace Mvcify.Core.Services.Interfaces
{
    public interface IDataSourceBinder<in TControl, in TData> where TControl : Control
            where TData : class
    {
        void Bind<TModel>(TModel model, TControl control, TData data) where TModel : class, INotifyPropertyChanged;
    }
}