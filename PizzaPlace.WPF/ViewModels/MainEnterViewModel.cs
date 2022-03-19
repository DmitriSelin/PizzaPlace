using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class MainEnterViewModel : ViewModel
    {
        private readonly IRepository<User> users;
        private readonly IUserService userService;
        private readonly MainWindowViewModel mainViewModel;

        #region Properties

        private string name;
        
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        private string surName;

        public string SurName
        {
            get => surName;
            set => Set(ref surName, value);
        }

        private string email;

        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }

        private string password;

        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        private string repeatPassword;

        public string RepeatPassword
        {
            get => repeatPassword;
            set => Set(ref repeatPassword, value);
        }

        #endregion

        #region Commands

        #region HomeCommand

        public ICommand BackHomeCommand { get; }

        private void OnBackHomeCommandExecuted(object p) => mainViewModel.GetEnterViewModel();

        #endregion

        #region OpenMainUserViewCommand

        public ICommand OpenMainUserViewCommand { get; }

        private void OnOpenMainUserViewCommandExecuted(object p)
        {
            try
            {
                userService.RegisterUser(Name, SurName, Email, Password, RepeatPassword);
                mainViewModel.GetMainUserViewModel();
            }
            catch (ArgumentNullException)
            {
                return;
            }
            catch (ArgumentException)
            {
                return;
            }
            catch(RepeatUserException)
            {
                return;
            }
            catch(PasswordException)
            {
                return;
            }
        }

        #endregion

        private bool CanExecute(object p) => true;

        #endregion

        public MainEnterViewModel(IRepository<User> _users, IUserService _userService, MainWindowViewModel _mainViewModel)
        {
            users = _users;
            userService = _userService;
            mainViewModel = _mainViewModel;

            #region Commands

            BackHomeCommand = new LambdaCommand(OnBackHomeCommandExecuted, CanExecute);

            OpenMainUserViewCommand = new LambdaCommand(OnOpenMainUserViewCommandExecuted, CanExecute);

            #endregion
        }
    }
}