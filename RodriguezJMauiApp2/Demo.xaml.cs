using RodriguezJMauiApp2.Repositorios;
using System.Threading.Tasks;

namespace RodriguezJMauiApp2;

public partial class Demo : ContentPage
{
	private ManejoArchivosRepository _repo;
	public Demo()
	{
		_repo = new ManejoArchivosRepository();

		InitializeComponent();
        ObtenerInformacionArchivo();
        
	}

	private async Task ObtenerInformacionArchivo()
	{
		texto1.Text = await _repo.ObtenerInformacionArchivo();
    }

	private async void BotonGuardar_Clicked(object sender , EventArgs e)
	{
		string texto = texto1.Text;
        Boolean guardar = await _repo.GuardarArchivo(texto);
		TextoArchivo.Text = await _repo.ObtenerInformacionArchivo();
    
        if (!guardar)
		{
            throw new Exception("No se pudo guardar el archivo");
        }


    }

}