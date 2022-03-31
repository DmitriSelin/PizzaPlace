using PizzaPlaceDB.DAL.Entities;
using System.Windows.Controls;
using System.Windows.Data;

namespace PizzaPlace.WPF.Views.UserControls
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void FilterFoodCollection(object sender, FilterEventArgs e)
        {
            if (e.Item is not Food food) return;

            if (food.Name is null) return;

            var filterText = FoodFilterText.Text;

            if (filterText.Length == 0) return;

            if (food.Name.Contains(filterText, System.StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

        private void OnFoodFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var foodCollection = (CollectionViewSource)textBox.FindResource("FoodCollection");

            foodCollection.View.Refresh();
        }
    }
}
