using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class EnterViewModel : ViewModel
    {
        #region Commands

        public ICommand OpenMainUserPageCommand { get; }

        private void OnOpenMainUserPageCommandExecuted(object p)
        {

        }

        private bool CanOpenMainUserPageCommandExecute(object p) => true;

        #endregion

        public EnterViewModel()
        {


            #region Commands

            OpenMainUserPageCommand = new LambdaCommand(OnOpenMainUserPageCommandExecuted, CanOpenMainUserPageCommandExecute);

            #endregion
        }
    }
}