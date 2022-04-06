using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;

namespace PizzaPlace.WPF.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Basket> baskets;
        private readonly IRepository<Food> food;

        private User user
        {
            get => MainWindowViewModel.User;
        }

        public StatisticViewModel(IRepository<Basket> _baskets, IRepository<Food> _food)
        {
            baskets = _baskets;
            food = _food;
        }
    }
}