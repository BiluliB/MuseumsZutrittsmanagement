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
    }
}
