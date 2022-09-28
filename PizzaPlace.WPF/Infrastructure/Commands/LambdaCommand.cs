using PizzaPlace.WPF.Infrastructure.Commands.BaseCommand;
using System;

namespace PizzaPlace.WPF.Infrastructure.Commands
{
    /// <summary>Class for creating commands</summary>
    class LambdaCommand : Command
    {
        private readonly Action<object> _execute;

        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(_execute));
            _canExecute = canExecute; 
        }

        /// <summary>Conditions for executing the command</summary>
        public override bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>Command's logic</summary>
        public override void Execute(object parameter) => _execute(parameter);
    }
}