using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Capataz : Empleado //herencia de parte de empleado 
    {

        public int _personasACargo { get; set; }

        public List<Tarea> _tareasAsignadas { get; set; }

        public List<Peon> _peones { get; set; }

        public Capataz() { }

        public Capataz(string email, string contrasenia, string nombre, DateTime fechaIngreso, int personasACargo,
            List<Tarea> tareasAsignadas, List<Peon> peones) : base(email, contrasenia, nombre, fechaIngreso)
        {

   
            _personasACargo = personasACargo;
            _tareasAsignadas = tareasAsignadas;
            _peones = peones;
        }

    }
}
