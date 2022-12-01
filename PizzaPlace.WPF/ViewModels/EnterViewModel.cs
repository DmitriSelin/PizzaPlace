using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    /// <summary>ViewModel for registered users</summary>
    public class EnterViewModel : ViewModel
    {
        private readonly IUserService userService;
        private readonly MainWindowViewModel mainViewModel;
        internal User User;
        private int enterClicks = 0;

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

        private Visibility passwordPopupVisibility = Visibility.Collapsed;

        public Visibility PasswordPopupVisibility
        {
            get => passwordPopupVisibility;
            set => Set(ref passwordPopupVisibility, value);
        }

        #endregion

        #region Commands

        #region OpenMainUserViewCommand

        public ICommand OpenMainUserViewCommand { get; }

        /// <summary>User Sign to the application</summary>
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
                MessageBox.Show("Incorrect email or password", "",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }
            catch(UserInputException)
            {
                enterClicks++;

                if (enterClicks % 5 == 0)
                {
                    int sleepTime = 15000;

                    PasswordPopupVisibility = Visibility.Visible;

                    MessageBox.Show($"You entered the password incorrectly {enterClicks} times", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    Thread.Sleep(sleepTime);

                    PasswordPopupVisibility = Visibility.Collapsed;

                    return;
                }
                
                MessageBox.Show("Not found user with these email and password", "",
                                MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
        }

        #endregion

        #region OpenMainEnterViewCommand

        public ICommand OpenMainEnterViewCommand { get; }

        private void OnOpenMainEnterViewCommandExecuted(object p) => mainViewModel.GetMainEnterViewModel();

        #endregion

        /// <summary>Conditions of executing</summary>
        /// <returns>true</returns>
        private bool CanExecute(object p) => true;

        #endregion

        public EnterViewModel(IUserService _userService, MainWindowViewModel _mainViewModel)
        {
            userService = _userService;
            mainViewModel = _mainViewModel;

            #region Commands

            OpenMainUserViewCommand = new LambdaCommand(OnOpenMainUserViewCommandExecuted, CanExecute);

            OpenMainEnterViewCommand = new LambdaCommand(OnOpenMainEnterViewCommandExecuted, CanExecute);

            #endregion
        }
    }
}