using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Kuwantima.Sandbox.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isDarkTheme;

        [ObservableProperty]
        private double _sliderValue = 60;

        [ObservableProperty]
        private double _progressValue = 45;

        [ObservableProperty]
        private bool _isToggled = true;

        [ObservableProperty]
        private bool _isChecked = true;

        public ObservableCollection<string> ListItems { get; } =
        [
            "Dashboard",
            "Fleet Overview",
            "Vehicle Tracking",
            "Route Planning",
            "Zone Management",
            "Site Configuration",
            "Alert History",
            "Driver Reports",
            "Fuel Analytics",
            "Maintenance Log",
            "Geofence Editor",
            "System Settings"
        ];
    }
}
