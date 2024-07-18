using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Potrero : IComparable<Potrero>
    {
        public int _id { get; set; }

        private static int s_contador = 0;

        public string _descripcion { get; set; }

        public double _cantidadHectareas { get; set; }

        public int _capacidadMaxAnimales { get; set; }

        public List<Animal> _animalesAlli { get; set; }


        public Potrero() { }

        public Potrero(string descripcion, double cantidadHectareas, int capacidadMaxAnimales, List<Animal> animalesAlli)
        {

            _id = s_contador++;
            _descripcion = descripcion;
            _cantidadHectareas = cantidadHectareas;
            _capacidadMaxAnimales = capacidadMaxAnimales;
            _animalesAlli = animalesAlli;

        }

        public bool LlegoAlMax() //calculo si el potrero esta al maximo 
        {
            if (_animalesAlli.Count >= _capacidadMaxAnimales)
            {
                return true;  //si llego al max devuelve true
            }
            return false;
        }

        public void AsignarAnimal(Animal animal)
        {
          
                _animalesAlli.Add(animal);
          
        }

        public decimal precioPotrero()
        {
            decimal precio = 0;
            foreach (Animal a in _animalesAlli)
            {
                precio += a.CalcularPrecio();
            }
            return precio;
        }

        public int CompareTo(Potrero obj)
        {
            //una de las formas de ordenamiento va a predominar
            int compareByCapacidad = this._capacidadMaxAnimales.CompareTo(obj._capacidadMaxAnimales);
            if (compareByCapacidad != 0)
            {
                return compareByCapacidad;
            }
            else
            {
             
                return obj._animalesAlli.Count.CompareTo(this._animalesAlli.Count);
            }
        }
    }
}

