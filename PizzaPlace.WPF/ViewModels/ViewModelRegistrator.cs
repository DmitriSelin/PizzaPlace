using Microsoft.Extensions.DependencyInjection;

namespace PizzaPlace.WPF.ViewModels
{
    /// <summary>allows to add the MainWindowViewModel</summary>
    public static class ViewModelRegistrator
    {
        /// <summary>Adding ViewModel</summary>
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
