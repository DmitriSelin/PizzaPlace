using PizzaPlace.WPF.Views.Pages;
using System.Windows;

namespace PizzaPlace.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Content = new EnterPage();
        }
    }
}
