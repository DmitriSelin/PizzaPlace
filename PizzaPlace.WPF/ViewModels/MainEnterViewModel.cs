using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class MainEnterViewModel : ViewModel
    {
        public static event Action BackHomeEvent;

        #region Commands

        public ICommand BackHomeCommand { get; }

        private void OnBackHomeCommandExecuted(object parametr)
        {
            BackHomeEvent?.Invoke();
        }

        #endregion

        public MainEnterViewModel()
        {
            #region Commands

            BackHomeCommand = new LambdaCommand(OnBackHomeCommandExecuted, CanExecute);

            #endregion
        }
    }
}
