using Microsoft.Extensions.DependencyInjection;

namespace PizzaPlace.WPF.ViewModels
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
