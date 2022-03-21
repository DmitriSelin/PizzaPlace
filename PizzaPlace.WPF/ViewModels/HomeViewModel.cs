using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System.Collections.ObjectModel;

namespace PizzaPlace.WPF.ViewModels
{
    internal class HomeViewModel : ViewModel
    {
        private readonly IRepository<Food> food;

        public ObservableCollection<Food> Food { get; }

        #region Properties

        private object selectedFood;

        public object SelectedFood
        {
            get => selectedFood;
            set => Set(ref selectedFood, value);
        }

        #endregion

        public HomeViewModel(IRepository<Food> _food)
        {
            food = _food;

            Food = new ObservableCollection<Food>(food.Items);
        }
    }
}
