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
            "�Gracias por tu inter�s!\n\nEsta es una aplicaci�n de demostraci�n desarrollada por Rodriguez J.",
            "OK");
    }
}