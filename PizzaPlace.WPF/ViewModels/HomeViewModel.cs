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
    /// <summary>ViewModel for choosing food and adding its to the basket</summary>
    internal class HomeViewModel : ViewModel
    {
        private readonly IRepository<Food> food;
        private readonly IRepository<Basket> baskets;
        private readonly IBasketService basketService;
        private User User
        {
            get => MainWindowViewModel.User;
        }

        /// <summary>Food entries from db</summary>
        public ObservableCollection<Food> Food { get; }

        #region Commands

        /// <summary>Conditions of executing</summary>
        /// <returns>true</returns>
        private bool CanExecute(object p) => true;

        #region AddToCartCommand

        public ICommand AddToCartCommand { get; }

        /// <summary>Adding to basket selected food</summary>
        private void OnAddToCartCommandExecuted(object p)
        {
            try
            {
                basketService.PutFoodToBasket(SelectedFood, User);
                Food.Remove((Food)SelectedFood);
            }
            catch(UserInputException)
            {
                return;
            }
            catch(RepeatUserException)
            {
                MessageBox.Show("You have already added this food to the cart", "",
                                MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
        }

        #endregion

        #endregion

        #region Properties

        private object selectedFood;

        public object SelectedFood
        {
            get => selectedFood;
            set => Set(ref selectedFood, value);
        }

        #endregion

        public HomeViewModel(IRepository<Food> _food, IRepository<Basket> _baskets, IBasketService _basketService)
        {
            food = _food;
            baskets = _baskets;
            basketService = _basketService;

            Food = new ObservableCollection<Food>(food.Items);

            #region Commands

            AddToCartCommand = new LambdaCommand(OnAddToCartCommandExecuted, CanExecute);

            #endregion
        }
    }
}