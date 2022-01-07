using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Controls;

namespace PizzaPlace.WPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public ViewModel CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new EnterViewModel();
        }
    }
}