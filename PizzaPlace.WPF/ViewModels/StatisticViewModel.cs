using LiveCharts;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.WPF.ViewModels
{
    /// <summary>ViewModel for charts, diagrams</summary>
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Basket> baskets;
        private readonly IRepository<Food> food;

        /// <summary>Basket entries from db</summary>
        public ObservableCollection<Basket> Baskets { get; }

        /// <summary>Food entries from db</summary>
        public ObservableCollection<Food> Food { get; }

        /// <summary>Food entries with foreign key in Baskets from db</summary>
        public ObservableCollection<Food> BasketFood { get; }

        public ChartValues<decimal> FoodPrices { get; set; }

        public ChartValues<string> FoodNames { get; set; }

        private User user
        {
            get => MainWindowViewModel.User;
        }

        public StatisticViewModel(IRepository<Basket> _baskets, IRepository<Food> _food)
        {
            baskets = _baskets;
            food = _food;

            Food = new ObservableCollection<Food>(food.Items);
            Baskets = new ObservableCollection<Basket>(baskets.Items);
            BasketFood = new ObservableCollection<Food>();

            FillBasketFood();

            FoodPrices = new ChartValues<decimal>(BasketFood.Select(x => x.Price));
            FoodNames = new ChartValues<string>(BasketFood.Select(x => x.Name));
        }

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