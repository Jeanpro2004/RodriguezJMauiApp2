namespace RodriguezJMauiApp2;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Contacto",
            "¡Gracias por tu interés!\n\nEsta es una aplicación de demostración desarrollada por Rodriguez J.",
            "OK");
    }
}