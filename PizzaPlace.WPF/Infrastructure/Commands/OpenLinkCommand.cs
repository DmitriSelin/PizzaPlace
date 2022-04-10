using PizzaPlace.WPF.Infrastructure.Commands.BaseCommand;
using System.Diagnostics;

namespace PizzaPlace.WPF.Infrastructure.Commands
{
    /// <summary>Open website command</summary>
    internal class OpenLinkCommand : Command
    {
        /// <summary>Command execution conditions</summary>
        /// <returns>true</returns>
        public override bool CanExecute(object parameter) => true;

        /// <summary>Opening a WebSite</summary>
        /// <param name="parameter">Link on WebSite</param>
        public override void Execute(object parameter)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {parameter.ToString()}")
            {
                CreateNoWindow = true
            });
        }
    }
}