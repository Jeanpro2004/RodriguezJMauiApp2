using RodriguezJMauiApp2.Repositorios;
using System.Threading.Tasks;

namespace RodriguezJMauiApp2;

public partial class Demo : ContentPage
{
    private ManejoArchivosRepository _repo;

    public Demo()
    {
        InitializeComponent();
        _repo = new ManejoArchivosRepository();
        _ = ObtenerInformacionArchivo();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ObtenerInformacionArchivo();
    }

    private async Task ObtenerInformacionArchivo()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            string contenido = await _repo.ObtenerInformacionArchivo();

            if (string.IsNullOrEmpty(contenido) || contenido == "No enccontre nada en el archivo")
            {
                TextoArchivo.Text = "📝 No hay notas guardadas aún.\n\n¡Escribe tu primera nota y guárdala!";
                TextoArchivo.TextColor = Colors.Gray;
            }
            else
            {
                TextoArchivo.Text = contenido;
                TextoArchivo.TextColor = Colors.Black;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al cargar las notas: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
        }
    }

    private async void BotonGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string texto = texto1.Text?.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                await DisplayAlert("Advertencia", "Por favor escribe algo antes de guardar.", "OK");
                return;
            }

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            // Agregar fecha y hora al texto
            string textoConFecha = $"[{DateTime.Now:dd/MM/yyyy HH:mm}]\n{texto}\n\n" +
                                  "═══════════════════════════════\n\n";

            bool guardado = await _repo.GuardarArchivo(textoConFecha);

            if (guardado)
            {
                await DisplayAlert("Éxito", "✅ Nota guardada correctamente", "OK");
                texto1.Text = string.Empty;
                await ObtenerInformacionArchivo();
            }
            else
            {
                await DisplayAlert("Error", " No se pudo guardar la nota", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error inesperado: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
        }
    }

    private async void BotonLimpiar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert("Confirmar",
            "¿Estás seguro de que quieres limpiar el texto actual?",
            "Sí", "No");

        if (confirmar)
        {
            texto1.Text = string.Empty;
            await DisplayAlert("Información", "Texto limpiado", "OK");
        }
    }
}