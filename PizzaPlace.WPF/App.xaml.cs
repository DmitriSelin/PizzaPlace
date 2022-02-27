using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaPlace.BL.Data;
using PizzaPlace.BL.Services;
using PizzaPlace.WPF.ViewModels;
using System;
using System.Windows;

namespace PizzaPlace.WPF
{
    public partial class App : Application
    {
        private static IHost host;

        public static IHost Host => host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase()
            .AddServices()
            .AddViewModel();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            base.OnStartup(e);

            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;

            base.OnExit(e);

            await host.StopAsync();
        }
    }
}
