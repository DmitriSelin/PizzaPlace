﻿using System;
using System.Windows.Input;

namespace PizzaPlace.WPF.Infrastructure.Commands.BaseCommand
{
    /// <summary>Base class for commands</summary>
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
