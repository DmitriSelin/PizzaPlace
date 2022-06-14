using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    /// <summary>Base ViewModel for working with another VMs</summary>
    internal class MainUserViewModel : ViewModel
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Basket> baskets;
        private readonly IRepository<Bonus> bonuses;
        private readonly IRepository<Category> categories;
        private readonly IRepository<Discount> discounts;
        private readonly IRepository<Food> food;
        private readonly IRepository<Order> orders;
        private readonly IBasketService basketService;
        private readonly ISaleService saleService;

        #region Fields and Properties

        internal User user;

        private ObservableCollection<Basket> basketFood;

        private ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        #endregion

        #region Commands

        private bool CanExecute(object p) => true;

        #region GetHomeViewModelCommand

        public ICommand GetHomeViewModelCommand { get; }

        private void OnGetHomeViewModelCommandExecuted(object p) =>
            CurrentViewModel = new HomeViewModel(food, baskets, basketService);

        #endregion

        #region GetBasketViewModelCommand

        public ICommand GetBasketViewModelCommand { get; }

        private void OnGetBasketViewModelCommandExecuted(object p) =>
            CurrentViewModel = new BasketViewModel(food, baskets, saleService);

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

        private void OnGetStatisticViewModelCommandExecuted(object p)
        {
            basketFood = new ObservableCollection<Basket>(baskets.Items);

            if (basketFood.Count > 0)
            {
                CurrentViewModel = new StatisticViewModel(baskets, food);
            }
            else
            {
                MessageBox.Show("You have no one food in your basket!");
            }
        }

        #endregion

        #endregion

        public MainUserViewModel(IRepository<User> _users, IRepository<Basket> _baskets,
                            IRepository<Bonus> _bonuses, IRepository<Category> _categories,
                            IRepository<Discount> _discounts, IRepository<Food> _food,
                            IRepository<Order> _orders, IBasketService _basketService,
                            ISaleService _saleService)
        {
            users = _users;
            baskets = _baskets;
            bonuses = _bonuses;
            categories = _categories;
            discounts = _discounts;
            food = _food;
            orders = _orders;
            basketService = _basketService;
            saleService = _saleService;
            user = MainWindowViewModel.User;

            currentViewModel = new HomeViewModel(food, baskets, basketService);

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