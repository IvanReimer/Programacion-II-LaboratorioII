using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool sePudoSerializar = false;
            try
            {
                XmlTextWriter archivoAEscribir = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(archivoAEscribir, datos);
                archivoAEscribir.Close();
                sePudoSerializar = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return sePudoSerializar;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool sePudoDescerializar = false;
            try
            {
                XmlTextReader archivoALeer = new XmlTextReader(archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                datos = (T)serializador.Deserialize(archivoALeer);
                archivoALeer.Close();
                sePudoDescerializar = true;
            }
            catch (Exception e )
            {
                throw new ArchivosException(e);
            }
            return sePudoDescerializar;

        }
    }
}
