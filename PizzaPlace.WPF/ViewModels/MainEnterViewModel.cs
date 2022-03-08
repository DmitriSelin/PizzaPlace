using PizzaPlace.BL.Exceptions;
using PizzaPlace.BL.Interfaces;
using PizzaPlace.WPF.Infrastructure.Commands;
using PizzaPlace.WPF.ViewModels.Base;
using PizzaPlaceDB.DAL.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaPlace.WPF.ViewModels
{
    internal class MainEnterViewModel : ViewModel
    {
        #region Events

        public static event Action BackHomeEvent;

        public static event Action OpenUserViewEvent;

        #endregion

        private readonly IRepository<User> users;
        private readonly IUserService userService;

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

        private void OnBackHomeCommandExecuted(object p)
        {
            BackHomeEvent?.Invoke();
        }

        private bool CanBackHomeCommandExecute(object p) => true;

        #endregion

        #region OpenMainUserViewCommand

        public ICommand OpenMainUserViewCommand { get; }

        private void OnOpenMainUserViewCommandExecuted(object p)
        {
            userService.RegisterUser(Name, SurName, Email, Password, RepeatPassword);
            OpenUserViewEvent?.Invoke();
        }

        private bool CanOpenMainUserViewCommandExecute(object p) => true;

        #endregion

        #endregion

        public MainEnterViewModel(IRepository<User> _users, IUserService _userService)
        {
            users = _users;
            userService = _userService;

            #region Commands

            BackHomeCommand = new LambdaCommand(OnBackHomeCommandExecuted, CanBackHomeCommandExecute);

            OpenMainUserViewCommand = new LambdaCommand(OnOpenMainUserViewCommandExecuted,
                                                        CanOpenMainUserViewCommandExecute);

            #endregion
        }
    }
}
