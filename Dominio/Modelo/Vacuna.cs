using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vacuna
    {
        public string _nombre { get; set; }

        public string _descripcion { get; set; }

        public string _patogenoAPrevenir { get; set; }

        public Vacuna() { }

        public Vacuna(string nombre, string descripcion, string patogenoAPrevenir)
        {

            _nombre = nombre;
            _descripcion = descripcion;
            _patogenoAPrevenir = patogenoAPrevenir;
        }


        public override bool Equals(object? obj) 
        {
            if (obj == null || !(obj is Vacuna)) return false;

            Vacuna otraVacuna = (Vacuna)obj;

            return _nombre == otraVacuna._nombre && _patogenoAPrevenir == otraVacuna._patogenoAPrevenir;
        }



    }
}
  