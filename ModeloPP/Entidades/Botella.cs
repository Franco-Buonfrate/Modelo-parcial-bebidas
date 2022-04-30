using System;
using System.Text;

namespace Entidades.Botellas
{
    public abstract class Botella
    {
        protected int capacidad;
        protected int contenido;
        protected string marca;
        protected double precio;

        public Botella(string marca, double precio, int capacidad)
        {
            this.marca = marca;
            this.precio = precio;
            this.capacidad = capacidad;
            contenido = capacidad;
        }
        public Botella(string marca, double precio) : this(marca, precio, 1000)
        {
        }

        public double PorcentajeContenido
        {
            get
            {
                return contenido;
            }
        }
        public abstract double Ganancia { get; }

        protected abstract void ServirMedida();

        private static string ObtenerDatos(Botella b)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"MARCA: {b.marca}");
            sb.AppendLine($"PRECIO: {b.precio}");
            sb.AppendLine($"CAPACIDAD: {b.capacidad}");
            sb.AppendLine($"CONTENIDO: {b.contenido}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ObtenerDatos(this);
        }
        public static bool operator ==(Botella b1, Botella b2)
        {
            return b1.marca == b2.marca && b1.capacidad == b2.capacidad;
        }
        public static bool operator !=(Botella b1, Botella b2)
        {
            return !(b1 == b2);
        }
        public static explicit operator string(Botella b)
        {
            return b.marca;
        }
        public static Botella operator --(Botella b)
        {
            b.ServirMedida();
            return b;
        }

    }
}

/*
Clase Botella (abstracta): Namespace: Entidades.Botellas
Tanto la capacidad como el contenido están expresados en centímetros cúbicos (cc). 
Constructor (+ 1 sobrecarga):
Las botellas tendrán una capacidad de 1000 cc de forma predeterminada (al inicializar, el contenido debe ser 
igual a la capacidad). Reutilizar código. 
Propiedades (sólo lectura):
PorcentajeContenido retornará el porcentaje actual del contenido de la botella.
La propiedad abstracta Ganancia, retornará la ganancia de la botella.
Métodos:
ServirMedida será abstracto y descuenta del contenido de la botella una unidad de medida. 
El método de clase ObtenerDatos será privado y retornará todos los datos de la botella. 
Aplicar polimorfismo en ToString, que retornará todos los datos de la botella. Reutilizar código.
Sobrecarga de operadores:
 Igualdad. Retornará true, si las marcas y las capacidades son iguales, false, caso contrario.
 Explícito. Retornará la marca de la botella que recibe como parámetro.
 Decremento. Saca de la botella que recibe como parámetro una unidad de medida. Reutilizar código.
 */