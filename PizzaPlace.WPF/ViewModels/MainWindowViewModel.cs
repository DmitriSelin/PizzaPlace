using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Commands

        public ICommand OpenLinkCommand { get; }

        #endregion

        private ViewModel currentViewModel = new EnterViewModel();

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }


        public MainWindowViewModel()
        {
            #region Commands

            OpenLinkCommand = new OpenLinkCommand();
            EnterViewModel.SignInButtonPressed += GetMainUserViewModel;
            EnterViewModel.LogInButtonPressed += GetMainEnterViewModel;

            #endregion
        }

        #region VM_Methods
        private void GetMainUserViewModel()
        {
            CurrentViewModel = new MainUserViewModel();
        }

        private void GetMainEnterViewModel()
        {
            CurrentViewModel = new MainEnterViewModel();
        }
        #endregion
    }
}