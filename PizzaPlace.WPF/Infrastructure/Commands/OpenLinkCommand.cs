using PizzaPlace.WPF.Infrastructure.Commands.BaseCommand;
using System.Diagnostics;

namespace PizzaPlace.WPF.Infrastructure.Commands
{
    internal class OpenLinkCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {parameter.ToString()}")
            { 
                CreateNoWindow = true
            });
        }
    }
}