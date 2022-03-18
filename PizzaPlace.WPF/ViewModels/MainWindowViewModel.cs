using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Basket> baskets;
        private readonly IRepository<Bonus> bonuses;
        private readonly IRepository<Category> categories;
        private readonly IRepository<Discount> discounts;
        private readonly IRepository<Food> food;
        private readonly IRepository<Order> orders;
        private readonly IUserService userService;

        #region Commands

        public ICommand OpenLinkCommand { get; }

        #endregion

        private ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }


        public MainWindowViewModel(IRepository<User> _users, IRepository<Basket> _baskets,
                            IRepository<Bonus> _bonuses, IRepository<Category> _categories,
                            IRepository<Discount> _discounts, IRepository<Food> _food,
                            IRepository<Order> _orders, IUserService _userService)
        {
            users = _users;
            baskets = _baskets;
            bonuses = _bonuses;
            categories = _categories;
            discounts = _discounts;
            food = _food;
            orders = _orders;
            userService = _userService;

            currentViewModel = new EnterViewModel(users, userService);

            #region Commands

            #region Events
            OpenLinkCommand = new OpenLinkCommand();
            EnterViewModel.SignInButtonPressed += GetMainUserViewModel;
            EnterViewModel.LogInButtonPressed += GetMainEnterViewModel;
            MainEnterViewModel.BackHomeEvent += GetEnterViewModel;
            MainEnterViewModel.OpenUserViewEvent += GetMainUserViewModel;
            #endregion

            #endregion
        }

        #region MethodsVM
        private void GetMainUserViewModel()
        {
            CurrentViewModel = new MainUserViewModel();
        }

        private void GetMainEnterViewModel()
        {
            CurrentViewModel = new MainEnterViewModel(users, userService);
        }

        private void GetEnterViewModel()
        {
            CurrentViewModel = new EnterViewModel(users, userService);
        }
        #endregion
    }
}