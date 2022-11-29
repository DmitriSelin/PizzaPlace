using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace PizzaPlace.WPF.Behaviors
{
    /// <summary>Binding PasswordBox</summary>
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBehavior),
                new PropertyMetadata(default(string)));

        private bool skipUpdate;

        public string Password
        {
            get => (string)GetValue(PasswordProperty);

            set => SetValue(PasswordProperty, value);
        }

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += PasswordBoxChanged;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == PasswordProperty)
            {
                if (!skipUpdate)
                {
                    skipUpdate = true;
                    AssociatedObject.Password = e.NewValue as string;
                    skipUpdate = false;
                }
            }
        }

        private void PasswordBoxChanged(object sender, RoutedEventArgs e)
        {
            skipUpdate = true;
            Password = AssociatedObject.Password;
            skipUpdate = false;
        }
    }
}