using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mvcify.Annotations;
using PropertyChanged;

namespace UiTest.Mvcify
{
    [ImplementPropertyChanged]
    public class SimpleModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public bool HasName => !string.IsNullOrWhiteSpace(Name);
        public string Description { get; set; }
        public bool HasDescription => !string.IsNullOrWhiteSpace(Description);
        public bool IsPublic { get; set; }
        public string Comment { get; set; }
        public string Product { get; set; }
        public List<string> Products { get; set; }
        public bool HasProduct => !string.IsNullOrWhiteSpace(Product);
    }
}