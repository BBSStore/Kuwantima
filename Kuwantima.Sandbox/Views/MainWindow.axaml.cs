using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using Kuwantima.Sandbox.ViewModels;

namespace Kuwantima.Sandbox.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Wire up theme toggle
            if (DataContext is MainWindowViewModel vm)
                SetupThemeToggle(vm);

            DataContextChanged += (_, _) =>
            {
                if (DataContext is MainWindowViewModel viewModel)
                    SetupThemeToggle(viewModel);
            };
        }

        private void SetupThemeToggle(MainWindowViewModel vm)
        {
            // Set initial state from current theme
            var app = Application.Current;
            if (app is null) return;

            vm.IsDarkTheme = app.ActualThemeVariant == ThemeVariant.Dark;

            vm.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(MainWindowViewModel.IsDarkTheme))
                {
                    app.RequestedThemeVariant = vm.IsDarkTheme
                        ? ThemeVariant.Dark
                        : ThemeVariant.Light;
                }
            };
        }
    }
}
