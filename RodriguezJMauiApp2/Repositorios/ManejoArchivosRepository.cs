using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodriguezJMauiApp2.Repositorios
{
    public class ManejoArchivosRepository
    {
        private string path = Path.Combine(FileSystem.AppDataDirectory, "mis_apuntes.txt");

        public async Task<bool> GuardarArchivo(string texto)
        {
            try
            {
                
                string contenidoExistente = string.Empty;

                if (File.Exists(path))
                {
                    contenidoExistente = await File.ReadAllTextAsync(path);
                }

                
                string contenidoFinal = contenidoExistente + texto;

                await File.WriteAllTextAsync(path, contenidoFinal, Encoding.UTF8);

                
                return File.Exists(path) && !string.IsNullOrEmpty(await File.ReadAllTextAsync(path));
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"Error al guardar archivo: {ex.Message}");
                return false;
            }
        }

        public async Task<string> ObtenerInformacionArchivo()
        {
            try
            {
                if (File.Exists(path))
                {
                    string texto = await File.ReadAllTextAsync(path, Encoding.UTF8);

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        return "El archivo está vacío";
                    }

                    return texto;
                }

                return "No se encontró ningún archivo de notas";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al leer archivo: {ex.Message}");
                return $"Error al cargar las notas: {ex.Message}";
            }
        }

        public async Task<bool> EliminarArchivo()
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return !File.Exists(path);
                }
                return true; 
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al eliminar archivo: {ex.Message}");
                return false;
            }
        }

        public async Task<FileInfo?> ObtenerInformacionDelArchivo()
        {
            try
            {
                if (File.Exists(path))
                {
                    return new FileInfo(path);
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al obtener información del archivo: {ex.Message}");
                return null;
            }
        }
    }
}