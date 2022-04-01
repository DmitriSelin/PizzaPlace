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
        private readonly IBasketService basketService;
        private readonly ISaleService saleService;
        private readonly MainEnterViewModel mainEnterViewModel;
        private readonly EnterViewModel enterViewModel;
        private readonly MainUserViewModel mainUserViewModel;

        internal static User User;

        #region Commands

        public ICommand OpenLinkCommand { get; }

        #endregion

        #region Properties

        private ViewModel currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        private string userName;

        public string UserName
        {
            get => userName;
            set => Set(ref userName, value);
        }

        #endregion


        public MainWindowViewModel(IRepository<User> _users, IRepository<Basket> _baskets,
                            IRepository<Bonus> _bonuses, IRepository<Category> _categories,
                            IRepository<Discount> _discounts, IRepository<Food> _food,
                            IRepository<Order> _orders, IUserService _userService,
                            IBasketService _basketService, ISaleService _saleService)
        {
            users = _users;
            baskets = _baskets;
            bonuses = _bonuses;
            categories = _categories;
            discounts = _discounts;
            food = _food;
            orders = _orders;
            userService = _userService;
            basketService = _basketService;
            saleService = _saleService;

            mainEnterViewModel = new MainEnterViewModel(users, userService, this);

            enterViewModel = new EnterViewModel(users, userService, this);

            mainUserViewModel = new MainUserViewModel(users, baskets, bonuses, categories, discounts,
                food, orders, basketService, saleService);

            currentViewModel = enterViewModel;

            #region Commands

            OpenLinkCommand = new OpenLinkCommand();

            #endregion
        }

        #region VM_Methods
        internal void GetMainUserViewModel()
        {
            CurrentViewModel = mainUserViewModel;
        }

        internal void GetMainEnterViewModel()
        {
            CurrentViewModel = mainEnterViewModel;
        }

        internal void GetEnterViewModel()
        {
            CurrentViewModel = enterViewModel;
        }
        #endregion
    }
}