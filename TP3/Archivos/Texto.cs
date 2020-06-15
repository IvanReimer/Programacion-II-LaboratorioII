using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool pudoGuardarElArchivo = false;
            try
            {
                StreamWriter escritorDeArchivo;
                escritorDeArchivo = new StreamWriter(archivo, true);
                escritorDeArchivo.Write(datos);
                escritorDeArchivo.Close();
                pudoGuardarElArchivo = true;
            }
            catch(ArgumentNullException e)
            {
                throw new ArchivosException(e);
            }
            catch (PathTooLongException e)
            {
                throw new ArchivosException(e);
            }
            catch (IOException e)
            {
                throw new ArchivosException(e);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return pudoGuardarElArchivo;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool pudoLeerElArchivo = false;
            try
            {
                StreamReader lectorDeArchivo;
                lectorDeArchivo = new StreamReader(archivo);
                datos = lectorDeArchivo.ReadToEnd();
                lectorDeArchivo.Close();
                pudoLeerElArchivo = true;
            }
            catch (FileNotFoundException e)
            {
                throw new ArchivosException(e);
            }
            catch(NotSupportedException e)
            {
                throw new ArchivosException(e);
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return pudoLeerElArchivo;
        }
    }
}
