using System.Collections.Generic;
using System.Windows.Forms;
using Mvcify.Core.Services;

namespace Mvcify.Core.Model
{
    public class BindingModel<TModel>
    {
        public BindingModel()
        {
            ControlDataBindings = new Dictionary<Control, IControlDataBindingModel<TModel>>();
        } 
        public Dictionary<Control, IControlDataBindingModel<TModel>> ControlDataBindings;
        //public DynamicProxy Proxy { get; set; }
        //public bool HasProxy => Proxy != null;
    }
}