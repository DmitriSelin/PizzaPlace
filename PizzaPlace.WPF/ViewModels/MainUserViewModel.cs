using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class MainUserViewModel : ViewModel
    {
        private ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        #region Commands

        private bool CanExecute(object p) => true;

        #region GetHomeViewModelCommand

        public ICommand GetHomeViewModelCommand { get; }

        private void OnGetHomeViewModelCommandExecuted(object p) => CurrentViewModel = new HomeViewModel();

        #endregion

        #region GetBasketViewModelCommand

        public ICommand GetBasketViewModelCommand { get; }

        private void OnGetBasketViewModelCommandExecuted(object p) => CurrentViewModel = new BasketViewModel();

        #endregion

        #region GetDiscountViewModelCommand

        public ICommand GetDiscountViewModelCommand { get; }

        private void OnGetDiscountViewModelCommandExecuted(object p) => CurrentViewModel = new DiscountViewModel();

        #endregion

        #region GetHistoryViewModelCommand

        public ICommand GetHistoryViewModelCommand { get; }

        private void OnGetHistoryViewModelCommandExecuted(object p) => CurrentViewModel = new HistoryViewModel();

        #endregion

        #region GetStatisticViewModelCommand

        public ICommand GetStatisticViewModelCommand { get; }

        private void OnGetStatisticViewModelCommandExecuted(object p) => CurrentViewModel = new StatisticViewModel();

        #endregion

        #endregion

        public MainUserViewModel()
        {
            currentViewModel = new HomeViewModel();

            #region Commands

            GetHomeViewModelCommand = new LambdaCommand(OnGetHomeViewModelCommandExecuted, CanExecute);

            GetBasketViewModelCommand = new LambdaCommand(OnGetBasketViewModelCommandExecuted, CanExecute);

            GetDiscountViewModelCommand = new LambdaCommand(OnGetDiscountViewModelCommandExecuted, CanExecute);

            GetHistoryViewModelCommand = new LambdaCommand(OnGetHistoryViewModelCommandExecuted, CanExecute);

            GetStatisticViewModelCommand = new LambdaCommand(OnGetStatisticViewModelCommandExecuted, CanExecute);
            #endregion
        }
    }
}
