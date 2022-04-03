using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;

namespace PizzaPlace.WPF.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Basket> baskets;
        private readonly IRepository<Food> food;

        public ObservableCollection<decimal> Prices { get; }

        public ObservableCollection<Basket> Baskets { get; }

        public ObservableCollection<Food> Food { get; }

        private User user
        {
            get => MainWindowViewModel.User;
        }

        public StatisticViewModel(IRepository<Basket> _baskets, IRepository<Food> _food)
        {
            baskets = _baskets;
            food = _food;

            Baskets = new ObservableCollection<Basket>(baskets.Items);
            Food = new ObservableCollection<Food>(food.Items);
            Prices = new ObservableCollection<decimal>();

            GetPrices();
        }

        private void GetPrices()
        {
            foreach(var basket in Baskets)
            {
                foreach(var product in Food)
                {
                    if (basket.FoodId == product.Id && basket.UserId == user.Id)
                    {
                        Prices.Add(product.Price);
                    }
                }
            }
        }
    }
}
