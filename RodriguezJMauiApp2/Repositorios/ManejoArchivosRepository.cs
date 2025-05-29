using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RodriguezJMauiApp2.Repositorios
{
    class ManejoArchivosRepository
    {
        private string path = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        public async Task<bool> GuardarArchivo(string texto)
        {
            try
            {
               
                await File.WriteAllTextAsync(path, texto);

                if (File.Exists(path))
                {
                    return true;

                }
                    return false;

                }

             catch (Exception)
            {
                return false;
            }

        }
         
        public async Task<string> ObtenerInformacionArchivo()
            {
            if (File.Exists(path))
            {
                string texto = await File.ReadAllTextAsync(path);
                return texto;
            }
            return "No enccontre nada en el archivo";
        }

        
    }
}
