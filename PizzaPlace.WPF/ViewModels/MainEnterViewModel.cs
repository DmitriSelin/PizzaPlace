using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class MainEnterViewModel : ViewModel
    {
        public static event Action BackHomeEvent;

        public static event Action OpenUserViewEvent;

        #region Commands

        #region HomeCommand
        public ICommand BackHomeCommand { get; }

        private void OnBackHomeCommandExecuted(object p)
        {
            BackHomeEvent?.Invoke();
        }

        private bool CanBackHomeCommandExecute(object p) => true;

        #endregion

        #region OpenMainUserViewCommand

        public ICommand OpenMainUserViewCommand { get; }

        private void OnOpenMainUserViewCommandExecuted(object p)
        {
            OpenUserViewEvent?.Invoke();
        }

        private bool CanOpenMainUserViewCommandExecute(object p) => true;

        #endregion

        #endregion

        public MainEnterViewModel()
        {
            #region Commands

            BackHomeCommand = new LambdaCommand(OnBackHomeCommandExecuted, CanBackHomeCommandExecute);

            OpenMainUserViewCommand = new LambdaCommand(OnOpenMainUserViewCommandExecuted,
                                                        CanOpenMainUserViewCommandExecute);

            #endregion
        }
    }
}
