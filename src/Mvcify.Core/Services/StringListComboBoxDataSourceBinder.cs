using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Mvcify.Core.Services.Interfaces;

namespace Mvcify.Core.Services
{
    public class StringListComboBoxDataSourceBinder : IDataSourceBinder<ComboBox, List<string>>
    {
        public void Bind<TModel>(TModel model, ComboBox control, List<string> data) where TModel : class, INotifyPropertyChanged
        {
            control.Items.Clear();
            foreach (var item in data)
            {
                control.Items.Add(item);
            }
        }
    }
}