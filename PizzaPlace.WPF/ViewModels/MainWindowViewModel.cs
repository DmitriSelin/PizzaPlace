using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlace.WPF.Views.Pages;
using System;
using System.Windows.Controls;

namespace PizzaPlace.WPF.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private Page enterPage;
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set => Set<Page>(ref currentPage, value);
        }

        public MainWindowViewModel()
        {
            enterPage = new EnterPage();

            CurrentPage = enterPage;
        }
    }
}