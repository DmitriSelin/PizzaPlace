using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class EnterViewModel : ViewModel
    {
        #region Commands

        #region VM_Commands

        public static event Action SignInButtonPressed;

        public static event Action LogInButtonPressed;

        public ICommand GetViewModelCommand { get; }

        private void OnGetViewModelCommandExecuted(object p)
        {
            if (p.ToString() == "MainUserView")
            {
                SignInButtonPressed?.Invoke();
            }
            else if (p.ToString() == "MainEnterView")
            {
                LogInButtonPressed?.Invoke();
            }
        }

        private bool CanGetViewModelCommandExecute(object p) => true;

        #endregion

        #endregion

        public EnterViewModel()
        {
            #region Commands

            GetViewModelCommand = new LambdaCommand(OnGetViewModelCommandExecuted, CanGetViewModelCommandExecute);

            #endregion
        }
    }
}