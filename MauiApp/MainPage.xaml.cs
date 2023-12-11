using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics; // Stellen Sie sicher, dass Sie diesen Namespace importieren für die Farben

namespace MuseumsZutrittMauiApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Color _visitorIndicatorColor;

        public Color VisitorIndicatorColor
        {
            get => _visitorIndicatorColor;
            set
            {
                if (_visitorIndicatorColor != value)
                {
                    _visitorIndicatorColor = value;
                    OnPropertyChanged(nameof(VisitorIndicatorColor));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            UpdateVisitorIndicator(21); // Hardcoded für dieses Beispiel
        }

        public void UpdateVisitorIndicator(int visitorCount)
        {
            VisitorIndicatorColor = visitorCount < 30 ? Colors.Green : Colors.Red;
        }

        // INotifyPropertyChanged Implementierung
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
