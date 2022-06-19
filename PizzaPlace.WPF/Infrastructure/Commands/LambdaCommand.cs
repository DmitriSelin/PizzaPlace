using PizzaPlace.WPF.Infrastructure.Commands.BaseCommand;
using System;

namespace PizzaPlace.WPF.Infrastructure.Commands
{
    /// <summary>Class for creating commands</summary>
    class LambdaCommand : Command
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }

        /// <summary>Conditions for executing the command</summary>
        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>Command's logic</summary>
        public override void Execute(object parameter) => execute(parameter);
    }
}