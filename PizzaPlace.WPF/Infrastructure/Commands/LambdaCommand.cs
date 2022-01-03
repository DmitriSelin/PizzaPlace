using PizzaPlace.WPF.Infrastructure.Commands.BaseCommand;
using System;

namespace PizzaPlace.WPF.Infrastructure.Commands
{
    class LambdaCommand : Command
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter) => execute(parameter);
    }
}
