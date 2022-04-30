using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Botellas
{
    public class Cerveza : Botella
    {
        public int medida;
        public TipoCerveza tipo;

        public Cerveza(string marca, double precio, int capacidad, TipoCerveza tipo, int medida) : base(marca, precio, capacidad)
        {
            this.tipo = tipo;
            this.medida = medida;
        }
        public Cerveza(string marca, double precio, int capacidad, TipoCerveza tipo) : this(marca, precio, capacidad, tipo, capacidad / 3)
        {
        }
        public override double Ganancia
        {
            get
            {
                return precio * 0.5;
            }
        }

        protected override void ServirMedida()
        {
            contenido -= medida;
            if (contenido < medida)
            {
                contenido = 0;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"MEDIDA: {medida}\nTIPO{tipo}\n";
        }
        public override bool Equals(object obj)
        {
            return obj is Cerveza && this == (Cerveza)obj;
        }
        public static bool operator ==(Cerveza c1, Cerveza c2)
        {
            return (Botella)c1 == c2 && c1.tipo == c2.tipo;
        }
        public static bool operator !=(Cerveza c1, Cerveza c2)
        {
            return !(c1 == c2);
        }

    }
}
/*
 Clase Cerveza (deriva de Botella): Namespace: Entidades.Botellas
La medida de cerveza se expresa en centímetros cúbicos (cc).
Constructor (+ 1 sobrecarga):
La medida predeterminada será de un tercio (1/3) de la capaciadad de la botella de cerveza. Reutilizar código.
Propiedades (sólo lectura):
Ganancia, retornará la ganancia de cada medida de la botella de cerveza, que será el 50% del precio total de 
la botella.
Métodos:
ServirMedida descontará, del contenido de la botella de cerveza, una medida. Si una vez descontada, el 
contenido restante de la botella de cerveza es menor al valor del atributo medida, se descartará, vaciando el 
contenido de la botella.
Aplicar polimorfismo en: 
ToString, que retornará todos los datos de la botella de cerveza. Reutilizar código.
Equals, que retornará true si el parámetro recibido es igual a la instancia actual. Reutilizar código.
Sobrecarga de operadores:
 Igualdad. Retornará true, si las botellas y los tipos de cerveza son iguales, false, caso contrario.
 */
