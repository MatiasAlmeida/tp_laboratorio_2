﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        /// <summary>
        /// Enumerados que indican la marca del producto.
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Constructor de Producto que inicializa con parametros los atributos marca, codigoDeBarras y 
        /// ColorPrimarioEmpaque.
        /// </summary>
        /// <param name="patente"> Código de barras del producto. </param>
        /// <param name="marca"> Marca del producto. </param>
        /// <param name="color"> Color del empaque del producto. </param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.codigoDeBarras = patente;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Propiedad que retonrna la cantidad de calorias del producto.
        /// </summary>
        public abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns> Devuelve una string con los datos del producto. </returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Sobrecarga del operador string para los objetos de Producto.
        /// </summary>
        /// <param name="p"> Objeto del tipo producto a sobrecargar con string. </param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras.
        /// </summary>
        /// <param name="v1"> Primer producto a comparar. </param>
        /// <param name="v2"> Segundo producto a comparar. </param>
        /// <returns> Retorna true si son iguales. </returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return v1.codigoDeBarras == v2.codigoDeBarras;
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"> Primer producto a comparar. </param>
        /// <param name="v2"> Segundo producto a comparar. </param>
        /// <returns> Retorna false si son distintos. </returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Redefinicion de Equals() para la clase abstracta Producto.
        /// Compara si dos productos son iguales.
        /// </summary>
        /// <param name="obj"> El objeto a comparar. </param>
        /// <returns> Retorna true si es el mismo objeto y false si no lo es. </returns>
        public override bool Equals(object obj)
        {
            return obj is Producto && (Producto)obj == this;
        }

        /// <summary>
        /// Para evitar la advertencia de GetHashCode().
        /// </summary>
        /// <returns> Retorna el HashCode de la clase base. </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
