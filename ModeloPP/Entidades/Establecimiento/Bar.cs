using Entidades.Botellas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Establecimiento
{
    public class Bar
    {
        private List<Botella> botellas;
        private int capacidadMaximaBotellas;
        private string nombre;
        private double recaudacion;

        public Bar()
        {
            this.botellas = new List<Botella>();
        }
        public Bar(int capacidad, string nombre) : this()
        {
            if (capacidad < 5)
            {
                this.capacidadMaximaBotellas = capacidad;
            }
            else
            {
                this.capacidadMaximaBotellas = 5;
            }

            this.nombre = nombre;
        }
        public Bar(int capacidad) : this(capacidad, "Sin nombre")
        {
        }

        public List<Botella> Botellas
        {
            get
            {
                return this.botellas;
            }
        }
        public string MostrarBar
        {
            get
            {
                return this.Mostrar();
            }
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE: {this.nombre}");
            sb.AppendLine($"RECAUDACION: {this.recaudacion}");
            sb.AppendLine($"CAPACIDAD MAX: {this.capacidadMaximaBotellas}");
            sb.AppendLine("-----------------------");
            foreach (Botella b in this.botellas)
            {
                sb.AppendLine(b.ToString());
                sb.AppendLine("-----------------------");
            }
            return sb.ToString();
        }

        public void OrdenarBotellas(Ordenamiento o)
        {
            switch (o)
            {
                case Ordenamiento.Ganancia:
                    this.botellas.Sort(OrdenarPorGanancia);
                    break;
                case Ordenamiento.Marca:
                    this.botellas.Sort(OrdenarPorMarca);
                    break;
                case Ordenamiento.PorcentajeContenido:
                    this.botellas.Sort(OrdenarPorContenido);
                    break;
            }
        }

        private int OrdenarPorGanancia(Botella a, Botella b)
        {
            if (a.Ganancia > b.Ganancia)
            {
                return 1;
            }
            else if (a.Ganancia < b.Ganancia)
            {
                return -1;
            }
            return 0;
        }
        private int OrdenarPorContenido(Botella a, Botella b)
        {
            if (a.PorcentajeContenido > b.PorcentajeContenido)
            {
                return 1;
            }
            else if (a.PorcentajeContenido < b.PorcentajeContenido)
            {
                return -1;
            }
            return 0;
        }
        private int OrdenarPorMarca(Botella a, Botella b)
        {
            return 1;
        }

        public static explicit operator double(Bar b)
        {
            return b.recaudacion;
        }
        public static bool operator ==(Bar a, Botella b)
        {
            return a.botellas.Contains(b);
        }
        public static bool operator !=(Bar a, Botella b)
        {
            return !(a == b);
        }

        public static Bar operator +(Bar bar, Botella bot)
        {
            if (bar.capacidadMaximaBotellas > bar.botellas.Count && bar != bot)
            {
                bar.botellas.Add(bot);
            }
            return bar;
        }
        public static Bar operator +(Bar bar, double g)
        {
            bar.recaudacion += g;
            return bar;
        }
        public static Bar operator -(Bar bar, Botella bot)
        {
            int indice;
            if (bar == bot)
            {
                indice = bar.botellas.IndexOf(bot);
                bar.botellas[indice]--;
                bar += bar.botellas[indice].Ganancia;
                if (bar.botellas[indice].PorcentajeContenido == 0)
                {
                    bar.botellas.RemoveAt(indice);
                }
            }
            return bar;
        }

    }
}
/*

 Adición, acumulará en la recaudación del bar recibido como primer parámetro, la ganancia recibida 
como segundo parámetro.
 Sustracción, si la botella se encuentra en el bar, se consumirá una medida de esa botella de agua o 
botella de cerveza. Se acumulará la ganancia correspondiente en el bar y si el porcentaje de contenido 
es cero, se quitará la botella del bar. Reutilizar código
 */
