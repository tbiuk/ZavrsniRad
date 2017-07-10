using PropertyChanged;
using System.ComponentModel;

namespace BusinessLogicLayer
{
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
