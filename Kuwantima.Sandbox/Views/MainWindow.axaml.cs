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

            if (DataContext is MainWindowViewModel vm)
                InitTheme(vm);

            DataContextChanged += (_, _) =>
            {
                if (DataContext is MainWindowViewModel viewModel)
                    InitTheme(viewModel);
            };
        }

        private void InitTheme(MainWindowViewModel vm)
        {
            var app = Application.Current;
            if (app is null) return;

            vm.IsDarkTheme = app.ActualThemeVariant == ThemeVariant.Dark;
        }
    }
}
