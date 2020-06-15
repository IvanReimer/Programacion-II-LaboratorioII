using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
namespace EntidadesAbstractas
{
    
    //[XmlInclude(typeof(Universitario))]
    //[XmlInclude(typeof(Profesor))]
    //[XmlInclude(typeof(Alumno))]
    public abstract class Persona
    {
        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Atributos

        private String apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private String nombre;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que inicializa y retorna el atributo privado apellido
        /// </summary>
        public String Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad que inicializa y retorna el atributo privado nombre.
        /// </summary>
        public String Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad que retorna e inicializa el atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que inicializa y retorna el atributo privado DNI previa validacion.
        /// </summary>
        public String StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad que inicializa el atributo DNI previa validacion.
        /// </summary>
        public int DNI 
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor necesario para serializar y deserializar
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor que inicializa los atributos nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">Nombre a asinar.</param>
        /// <param name="apellido">Apellido a asignar.</param>
        /// <param name="nacionalidad">Nacionalidad a asignar.</param>
        public Persona(String nombre, String apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor que inicializa los atributos nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="nombre">Nombre a inicializar</param>
        /// <param name="apellido">Apellido a inicializar</param>
        /// <param name="dni">DNI a inicializar</param>
        /// <param name="nacionalidad">Nacionalidad a inicializar</param>
        public Persona(String nombre, String apellido, int dni, ENacionalidad nacionalidad) :this(nombre,apellido,dni.ToString(),nacionalidad)
        {
            this.dni = dni;
        }
        /// <summary>
        /// Constructor que inicializa nombre, apellido, dni en formato string y nacionalidad
        /// </summary>
        /// <param name="nombre">Nombre a inicializar</param>
        /// <param name="apellido">Apellido a inicializar</param>
        /// <param name="dni">DNI a inicializar</param>
        /// <param name="nacionalidad">Nacionalidad a inicializar</param>
        public Persona(String nombre, String apellido, String dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion

        #region Métodos
        /// <summary>
        /// Valida que el dni ingresado como dato pertenezca a un rango particular.
        /// Entre 1 y 89999999 si es Argentino y entre 90000000 y 99999999 si es extranjero.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a validar</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>El dni en caso de que se corresponda con la nacionalidad y se ajuste a los requisitos explicados en el summary.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
            }
            return dniValidado;
        }
        /// <summary>
        /// Este método valida que el DNI ingresado por parametro se ajuste a un numero entero y llama su sobrecarga
        /// validarDni para probar que se ajuste a los datos pasados por parametro.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a validar</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>El dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, String dato)
        {
            int dniValidado = 0;
            if (int.TryParse(dato, out dniValidado))
            {
                dniValidado = this.ValidarDni(nacionalidad, dniValidado);
            }
            else
            {
                throw new DniInvalidoException("DNI invalido.");
            }
            return dniValidado;
        }
        private String ValidarNombreApellido(String dato)
        {
            String nombreApellidoValidado = String.Empty;
            Regex validadorDeLetras = new Regex(@"^[A-ZÁÉÍÓÚ][a-záéíóú]+");
            if (validadorDeLetras.IsMatch(dato))
            {
                nombreApellidoValidado = dato;
            }
            return nombreApellidoValidado;
        }
        #endregion

        #region Sobrescrituras
        /// <summary>
        /// Este método sobrescribe el método ToString para devolver los datos de la persona
        /// </summary>
        /// <returns>Los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(String.Format("NOMBRE COMPLETO: {0}, {1}", this.apellido, this.nombre));
            datos.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            return datos.ToString();
        }
        #endregion

    }
}
