using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaPlace.WPF.ViewModels.Base
{
    /// <summary>Base class for organization MVVM pattern</summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Invoking the PropertyChanged event</summary>
        /// <param name="propertyName">Object, that triggered the event</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Setting a new value and invoking the PropertyChanged event</summary>
        /// <returns>Comparison field and value</returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
