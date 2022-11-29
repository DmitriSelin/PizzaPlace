using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    /// <summary>ViewModel for buying food</summary>
    internal class BasketViewModel : ViewModel
    {
        private readonly IRepository<Food> food;
        private readonly IRepository<Basket> baskets;
        private readonly ISaleService saleService;

        #region Properties

        private object selectedFood;

        public object SelectedFood
        {
            get => selectedFood;
            set => Set(ref selectedFood, value);
        }

        private Visibility noBasketFoodTextBlockVisibility;

        public Visibility NoBasketFoodTextBlockVisibility
        {
            get => noBasketFoodTextBlockVisibility;
            set => Set(ref noBasketFoodTextBlockVisibility, value);
        }

        private User user => MainWindowViewModel.User;

        /// <summary>Food entries from db</summary>
        public ObservableCollection<Food> Food { get; }

        /// <summary>Baskets entries from db</summary>
        public ObservableCollection<Basket> Baskets { get; }

        /// <summary>Food entries with foreign key in Baskets from db</summary>
        public ObservableCollection<Food> BasketFood { get; private set; }

        #endregion

        #region Commands

        /// <summary>Conditions of executing</summary>
        /// <returns>true</returns>
        private bool CanExecute(object p) => true;

        #region BuyCommand

        public ICommand BuyCommand { get; }

        /// <summary>Buying user's selected food </summary>
        private void OnBuyCommandExecuted(object p)
        {
            try
            {
                saleService.BuyFood(SelectedFood, user);
                BasketFood.Remove((Food)SelectedFood);

                if (BasketFood.Count == 0 || Baskets.Count == 0)
                {
                    NoBasketFoodTextBlockVisibility = Visibility.Visible;
                }
                else
                {
                    NoBasketFoodTextBlockVisibility = Visibility.Collapsed;
                }
            }
            catch (UserInputException)
            {
                MessageBox.Show("You don't select any pizza", "", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }
        }

        #endregion

        #endregion

        public BasketViewModel(IRepository<Food> _food, IRepository<Basket> _baskets,
            ISaleService _saleService)
        {
            food = _food;
            baskets = _baskets;
            saleService = _saleService;

            Food = new ObservableCollection<Food>(food.Items);
            Baskets = new ObservableCollection<Basket>(baskets.Items);

            if (Baskets.Count == 0)
            {
                noBasketFoodTextBlockVisibility = Visibility.Visible;
            }
            else
            {
                noBasketFoodTextBlockVisibility = Visibility.Collapsed;

                BasketFood = new ObservableCollection<Food>();

                FillBasketFood();
            }

            #region Commands

            BuyCommand = new LambdaCommand(OnBuyCommandExecuted, CanExecute);

            #endregion
        }

        /// <summary>Adding food, added to basket, to Baskets</summary>
        private void FillBasketFood()
        {
            BasketFood.Clear();

            foreach (var basket in Baskets)
            {
                foreach (var basketFood in Food)
                {
                    if (basket.FoodId == basketFood.Id && basket.UserId == user.Id)
                    {
                        BasketFood.Add(basketFood);
                    }
                }
            }

            OnPropertyChanged();
        }
    }
}