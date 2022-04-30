using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Botellas
{
    public class Agua : Botella
    {
        public TipoAgua tipo;
        public Agua(string marca, double precio, int capacidad, TipoAgua tipo) : base(marca, precio, capacidad)
        {
            this.tipo = tipo;
        }
        public Agua(string marca, double precio, TipoAgua tipo) : this(marca, precio, 500, tipo)
        {
        }

        public override double Ganancia
        {
            get
            {
                return precio * 1.25;
            }
        }

        protected override void ServirMedida()
        {
            contenido = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"TIPO: {tipo}\n";
        }
        public override bool Equals(object obj)
        {
            return obj is Agua && this == (Agua)obj;
        }
        public static bool operator ==(Agua a1, Agua a2)
        {
            return (Botella)a1 == a2 && a1.tipo == a2.tipo;
        }
        public static bool operator !=(Agua a1, Agua a2)
        {
            return !(a1 == a2);
        }

    }
}
/*
 Clase Agua (deriva de Botella): Namespace: Entidades.Botellas
Constructor (+ 1 sobrecarga):
Las botellas de agua tendrán, de forma predeterminada, una capacidad de 500 cc. Reutilizar código.
Propiedades (sólo lectura):
Ganancia, retornará la ganancia de la botella de agua, que será un 25% más del precio total de la botella.
Métodos:
ServirMedida gastará todo el contenido de la botella de agua. La medida de esta botella será la totalidad de la 
misma.
Aplicar polimorfismo en: 
ToString, que retornará todos los datos de la botella de agua. Reutilizar código.
Equals, que retornará true si el parámetro recibido es igual a la instancia actual. Reutilizar código.
Sobrecarga de operadores:
 Igualdad. Retornará true, si las botellas y los tipos de agua son iguales, false, caso contrario.
 */
