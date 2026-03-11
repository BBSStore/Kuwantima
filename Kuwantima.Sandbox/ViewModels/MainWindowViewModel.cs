using System.Linq;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Kuwantima.Sandbox.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static string KuwantimaVersion =>
            typeof(Kuwantima.Sandbox.App).Assembly
                .GetReferencedAssemblies()
                .FirstOrDefault(a => a.Name == "Kuwantima")
                ?.Version?.ToString(3) ?? "0.0.0";

        [ObservableProperty]
        private bool _isDarkTheme;

        partial void OnIsDarkThemeChanged(bool value)
        {
            var variant = value ? ThemeVariant.Dark : ThemeVariant.Light;

            if (Application.Current is { } app)
                app.RequestedThemeVariant = variant;
        }

        [ObservableProperty]
        private int _selectedPageIndex;

        [ObservableProperty]
        private bool _isPaneOpen = true;

        [ObservableProperty]
        private double _sliderValue = 60;

        [ObservableProperty]
        private double _progressValue = 45;

        [ObservableProperty]
        private bool _isToggled = true;

        [ObservableProperty]
        private bool _isChecked = true;

        partial void OnSelectedPageIndexChanged(int value)
        {
            OnPropertyChanged(nameof(IsButtonsPageVisible));
            OnPropertyChanged(nameof(IsInputsPageVisible));
            OnPropertyChanged(nameof(IsTogglesPageVisible));
            OnPropertyChanged(nameof(IsFeedbackPageVisible));
            OnPropertyChanged(nameof(IsContainersPageVisible));
            OnPropertyChanged(nameof(IsThemePreviewPageVisible));
            OnPropertyChanged(nameof(IsDocumentsPageVisible));
        }

        public bool IsButtonsPageVisible => SelectedPageIndex == 0;
        public bool IsInputsPageVisible => SelectedPageIndex == 1;
        public bool IsTogglesPageVisible => SelectedPageIndex == 2;
        public bool IsFeedbackPageVisible => SelectedPageIndex == 3;
        public bool IsContainersPageVisible => SelectedPageIndex == 4;
        public bool IsThemePreviewPageVisible => SelectedPageIndex == 5;
        public bool IsDocumentsPageVisible => SelectedPageIndex == 6;

        [RelayCommand]
        private void NavigateTo(string pageIndex)
        {
            if (int.TryParse(pageIndex, out var index))
                SelectedPageIndex = index;
        }

        [RelayCommand]
        private void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
