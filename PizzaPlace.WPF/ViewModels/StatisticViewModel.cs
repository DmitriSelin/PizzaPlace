using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

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

        public CartesianMapper<ObservableValue> Mapper { get; set; }

        #region Brushes

        private Brush forestGreenBrush = new SolidColorBrush(Colors.ForestGreen);

        private Brush darkOrangeBrush = new SolidColorBrush(Colors.DarkOrange);

        private Brush darkBlueBrush = new SolidColorBrush(Colors.DarkBlue);

        #endregion

        public ChartValues<decimal> FoodPrices { get; private set; }

        public ChartValues<string> FoodNames { get; private set; }

        private User user => MainWindowViewModel.User;

        public StatisticViewModel(IRepository<Basket> _baskets, IRepository<Food> _food)
        {
            baskets = _baskets;
            food = _food;

            Food = new ObservableCollection<Food>(food.Items);
            Baskets = new ObservableCollection<Basket>(baskets.Items);
            BasketFood = new ObservableCollection<Food>();

            FillBasketFood();

            Mapper = Mappers.Xy<ObservableValue>()
                .X((item, index) => index)
                .Y(item => item.Value)
                .Fill(item => item.Value > 40 ? forestGreenBrush : darkOrangeBrush);

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