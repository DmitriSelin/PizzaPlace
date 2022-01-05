using System;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class EnterPageViewModel : ViewModel
    {
        #region Commands
        
        public ICommand OpenMainPageCommand { get; }

        private void OnOpenMainPageCommandExecuted(object p)
        {
            
        }

        private bool CanOpenMainPageCommandExecute(object p) => true;

        #endregion

        public EnterPageViewModel()
        {
            #region Commands

            OpenMainPageCommand = new LambdaCommand(OnOpenMainPageCommandExecuted, CanOpenMainPageCommandExecute);

            #endregion
        }
    }
}
