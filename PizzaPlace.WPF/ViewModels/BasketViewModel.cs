using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class BasketViewModel : ViewModel
    {
        private readonly IRepository<Food> food;
        private readonly IRepository<Basket> baskets;

        private object selectedFood;

        public object SelectedFood
        {
            get => selectedFood;
            set => Set(ref selectedFood, value);
        }

        private User user => MainWindowViewModel.User;

        public ObservableCollection<Food> Food { get; }

        public ObservableCollection<Basket> Baskets { get; }

        public ObservableCollection<Food> BasketFood { get; private set; }

        #region Commands

        private bool CanExecute(object p) => true;

        #region BuyCommand

        public ICommand BuyCommand { get; }

        private void OnBuyCommandExecuted(object p)
        {
            try
            {

            }
            catch
            {

            }
        }

        #endregion

        #endregion

        public BasketViewModel(IRepository<Food> _food, IRepository<Basket> _baskets)
        {
            food = _food;
            baskets = _baskets;

            Food = new ObservableCollection<Food>(food.Items);
            Baskets = new ObservableCollection<Basket>(baskets.Items);
            BasketFood = new ObservableCollection<Food>();

            FillBasketFoodCollection();

            #region Commands

            BuyCommand = new LambdaCommand(OnBuyCommandExecuted, CanExecute);

            #endregion
        }

        private void FillBasketFoodCollection()
        {
            for (var i = 0; i < Baskets.Count; i++)
            {
                for (var j = 0; j < Baskets.Count; j++)
                {
                    if (Baskets[i].FoodId == Food[j].Id && Baskets[i].UserId == user.Id)
                    {
                        BasketFood.Add(Food[i]);
                    }
                }
            }

            OnPropertyChanged();
        }
    }
}
