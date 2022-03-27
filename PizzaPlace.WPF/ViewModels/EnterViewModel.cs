using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    public class EnterViewModel : ViewModel
    {
        private readonly IRepository<User> users;
        private readonly IUserService userService;
        private readonly MainWindowViewModel mainViewModel;
        internal User User;

        #region Properties

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

        #endregion

        #region Commands

        #region OpenMainUserViewCommand

        public ICommand OpenMainUserViewCommand { get; }

        private void OnOpenMainUserViewCommandExecuted(object p)
        {
            try
            {
                User = userService.SignInApp(Email, Password);
                mainViewModel.GetMainUserViewModel();
                mainViewModel.UserName = User.Name;
                MainWindowViewModel.User = User;
            }
            catch(ArgumentNullException)
            {
                return;
            }
            catch(UserInputException)
            {
                return;
            }
        }

        #endregion

        #region OpenMainEnterViewCommand

        public ICommand OpenMainEnterViewCommand { get; }

        private void OnOpenMainEnterViewCommandExecuted(object p) => mainViewModel.GetMainEnterViewModel();

        #endregion

        private bool CanExecute(object p) => true;

        #endregion

        public EnterViewModel(IRepository<User> _users, IUserService _userService, MainWindowViewModel _mainViewModel)
        {
            users = _users;
            userService = _userService;
            mainViewModel = _mainViewModel;

            #region Commands

            OpenMainUserViewCommand = new LambdaCommand(OnOpenMainUserViewCommandExecuted, CanExecute);

            OpenMainEnterViewCommand = new LambdaCommand(OnOpenMainEnterViewCommandExecuted, CanExecute);

            #endregion
        }
    }
}