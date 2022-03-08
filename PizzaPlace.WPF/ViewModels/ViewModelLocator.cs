using Microsoft.Extensions.DependencyInjection;

namespace PizzaPlace.WPF.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel =>
                App.Services.GetRequiredService<MainWindowViewModel>();
    }
}