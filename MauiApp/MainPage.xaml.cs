using System.ComponentModel;
using Microsoft.Maui.Controls;
using MuseumsZutrittMauiApp.ViewModels;


namespace MuseumsZutrittMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        private async Task AnimateButton(Button button)
        {
            await Task.WhenAll(
                button.ScaleTo(0.99, 50, Easing.Linear), // Leicht verkleinern
                button.FadeTo(0.8, 50, Easing.Linear) // Opazität reduzieren
            );
            await Task.WhenAll(
                button.ScaleTo(1, 50, Easing.Linear), // Zurück zur ursprünglichen Größe
                button.FadeTo(1, 50, Easing.Linear) // Opazität zurücksetzen
            );
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await AnimateButton(sender as Button);
            // Weitere Logik für den Button
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            var button = sender as Button;
            await Task.WhenAll(
                button.ScaleTo(0.99, 50, Easing.Linear), // Leicht verkleinern
                button.FadeTo(0.8, 50, Easing.Linear) // Opazität reduzieren
            );
        }

        private async void Button_Released(object sender, EventArgs e)
        {
            var button = sender as Button;
            await Task.WhenAll(
                button.ScaleTo(1, 50, Easing.Linear), // Zurück zur ursprünglichen Größe
                button.FadeTo(1, 50, Easing.Linear) // Opazität zurücksetzen
            );
        }


    }
}
