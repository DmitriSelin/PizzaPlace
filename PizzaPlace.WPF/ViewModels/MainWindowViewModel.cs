using PizzaPlace.WPF.ViewModels.Base;

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