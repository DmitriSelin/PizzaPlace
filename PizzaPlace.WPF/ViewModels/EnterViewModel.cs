using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class EnterViewModel : ViewModel
    {
        #region Commands

        public ICommand GetMainUserViewModelCommand { get; }

        private void OnGetMainUserViewModelCommandExecuted(object p)
        {
            
        }

        private bool CanGetMainUserViewModelCommandExecute(object p) => true;

        #endregion

        public EnterViewModel()
        {
            #region Commands

            GetMainUserViewModelCommand = new LambdaCommand(OnGetMainUserViewModelCommandExecuted,
                                                            CanGetMainUserViewModelCommandExecute);

            #endregion
        }
    }
}