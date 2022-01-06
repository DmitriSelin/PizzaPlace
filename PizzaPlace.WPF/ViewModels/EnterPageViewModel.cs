using System;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows.Controls;
using PizzaPlace.WPF.Views.Pages;

namespace PizzaPlace.WPF.ViewModels
{
    internal class EnterPageViewModel : ViewModel
    {
        private Page mainUserPage;
        private Page registrationPage;

        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set => Set<Page>(ref currentPage, value);
        }

        #region Commands

        public ICommand OpenMainUserPageCommand { get; }

        private void OnOpenMainUserPageCommandExecuted(object p)
        {
            CurrentPage = mainUserPage;
        }

        private bool CanOpenMainUserPageCommandExecute(object p) => true;

        #endregion

        public EnterPageViewModel()
        {
            mainUserPage = new MainUserPage();
            registrationPage = new RegistrationPage();

            #region Commands

            OpenMainUserPageCommand = new LambdaCommand(OnOpenMainUserPageCommandExecuted, CanOpenMainUserPageCommandExecute);

            #endregion
        }
    }
}