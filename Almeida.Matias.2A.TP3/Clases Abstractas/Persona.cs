﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.DNI = ValidarDni(this.Nacionalidad, value); }
        }

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", this.Nacionalidad.ToString());
            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // Lo mismo que para el metodo anterior.
            /*try
            {
                int aux = int.Parse(dato);
            }
            catch (Exception e)
            {
                if (int.Parse(dato) < 1 || int.Parse(dato) > 99999999 || !dato.Any(char.IsDigit))
                {
                    /*throw new DniInvalidoException("Error: " + "Error. El DNI debe contener entre 1 y 8 caracteres, ser un " +
                "entero positivo y ademas debe contener SOLO numeros.\n" + e.Message); 
                    // Pondria la linea de arriba en caso de querer arrojar ambos errores, o podria poner todo este try-catch
                    // dentro de otro bloque try-catch y trabajar con las Inner Exceptions.
                    // Recordar que cuando trabaje en el nuevo bloque try-catch, la e.Message actual sera la de DniInvalidoException,
                    // y la e.InnerException sera la excepcion que tome el catch anidado (o sea el de este bloque).
                    DniInvalidoException nuevo = new DniInvalidoException(e); // Esto llama al constructor que hace el throw 
                }

                Console.WriteLine(e.Message);
            }*/


            // Este if es 100% funcional para esta situacion porque el Main usa cadenas de caracteres numericos sin ningun caracter
            // que pueda llegar a ser motivo para arrojar una excepcion especifica.
            if (int.TryParse(dato, out int aux) == true)
            {
                if (aux < 1 || aux > 99999999 || !aux.ToString().Any(char.IsDigit))
                {
                    throw new DniInvalidoException();
                }
                else if ((aux >= 1 && aux <= 89999999 && this.Nacionalidad != ENacionalidad.Argentino) || (aux >= 90000000 && aux <= 99999999 && this.Nacionalidad != ENacionalidad.Extranjero))
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return aux;
        }

        private string ValidarNombreApellido(string dato)
        {
            if (!dato.Any(char.IsLetter))
                dato = null;

            return dato;
        }
    }
}
