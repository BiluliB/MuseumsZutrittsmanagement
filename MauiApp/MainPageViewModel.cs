using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Graphics;

namespace MuseumsZutrittMauiApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _besucherBereich1;
        private int _besucherBereich2;
        private Color _indicatorColor;
        private bool _istBereich1Ausgewaehlt;
        private bool _istBereich2Ausgewaehlt;

        public int BesucherBereich1
        {
            get => _besucherBereich1;
            set
            {
                _besucherBereich1 = value;
                OnPropertyChanged(nameof(BesucherBereich1));
                UpdateIndicatorColor();
            }
        }

        public int BesucherBereich2
        {
            get => _besucherBereich2;
            set
            {
                _besucherBereich2 = value;
                OnPropertyChanged(nameof(BesucherBereich2));
                UpdateIndicatorColor();
            }
        }

        public Color IndicatorColor
        {
            get => _indicatorColor;
            set
            {
                _indicatorColor = value;
                OnPropertyChanged(nameof(IndicatorColor));
            }
        }

        public bool IstBereich1Ausgewaehlt
        {
            get => _istBereich1Ausgewaehlt;
            set
            {
                if (_istBereich1Ausgewaehlt != value)
                {
                    _istBereich1Ausgewaehlt = value;
                    OnPropertyChanged(nameof(IstBereich1Ausgewaehlt));
                    OnPropertyChanged(nameof(SelectedBereich));
                    UpdateIndicatorColor(); // Hier wird die Methode aufgerufen
                }
            }
        }

        public bool IstBereich2Ausgewaehlt
        {
            get => _istBereich2Ausgewaehlt;
            set
            {
                if (_istBereich2Ausgewaehlt != value)
                {
                    _istBereich2Ausgewaehlt = value;
                    OnPropertyChanged(nameof(IstBereich2Ausgewaehlt));
                    OnPropertyChanged(nameof(SelectedBereich));
                    UpdateIndicatorColor(); // Hier wird die Methode aufgerufen
                }
            }
        }

        public string SelectedBereich
        {
            get
            {
                if (IstBereich1Ausgewaehlt)
                    return "Bereich 1";
                else if (IstBereich2Ausgewaehlt)
                    return "Bereich 2";
                else
                    return string.Empty;
            }
        }

        public ICommand EintrittCommand { get; }
        public ICommand AustrittCommand { get; }

        public MainPageViewModel()
        {
            EintrittCommand = new Command(HandleEintritt);
            AustrittCommand = new Command(HandleAustritt);
            IndicatorColor = Colors.Green; // Setzen Sie eine Standardfarbe
            IstBereich1Ausgewaehlt = true;

            PropertyChanged += OnSelectedBereichChanged;
        }

        private void OnSelectedBereichChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedBereich))
            {
                UpdateIndicatorColor();
            }
        }

        private void UpdateIndicatorColor()
        {
            if (SelectedBereich == "Bereich 1")
                IndicatorColor = BesucherBereich1 >= 35 ? Colors.Red : Colors.Green;
            else if (SelectedBereich == "Bereich 2")
                IndicatorColor = BesucherBereich2 >= 20 ? Colors.Red : Colors.Green;
        }

        private void HandleEintritt()
        {
            if (SelectedBereich == "Bereich 1")
                BesucherBereich1++; // Erhöhe den Zähler für Bereich 1
            else if (SelectedBereich == "Bereich 2")
                BesucherBereich2++; // Erhöhe den Zähler für Bereich 2

            UpdateIndicatorColor();
        }

        private void HandleAustritt()
        {
            if (SelectedBereich == "Bereich 1" && BesucherBereich1 > 0)
                BesucherBereich1--; // Verringere den Zähler für Bereich 1
            else if (SelectedBereich == "Bereich 2" && BesucherBereich2 > 0)
                BesucherBereich2--; // Verringere den Zähler für Bereich 2

            UpdateIndicatorColor();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
