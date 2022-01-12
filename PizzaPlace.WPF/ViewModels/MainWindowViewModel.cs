using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Commands

        public ICommand OpenLinkCommand { get; }

        #endregion


        private ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            currentViewModel = new EnterViewModel();

            #region Commands

            OpenLinkCommand = new OpenLinkCommand();

            #endregion
        }
    }
}