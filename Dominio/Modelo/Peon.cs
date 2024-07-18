using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dominio
{
    public class Peon : Empleado //herencia de parte de empleado 
    {

        public bool _residente { get; set; }

        public List<Tarea> _tareasAsignadas { get; set; }

        public Peon() { }

        public Peon(string email, string contrasenia, string nombre, DateTime fechaIngreso, bool residente,
        List<Tarea> tareasAsignadas) : base(email, contrasenia, nombre, fechaIngreso)
        {

            _residente = residente;
            _tareasAsignadas = tareasAsignadas;

        }

        public Tarea CompletarUnaTarea(int id, string comentario)
        {
            foreach (Tarea t in _tareasAsignadas)
            {
                if (t._id == id)
                {
                    t._comentarioPeon = comentario;
                    t._completa = true;
                    return t;
                }
            }
            return null;
        }


        public void Asignar(Tarea tarea)
        {
            _tareasAsignadas.Add(tarea);

        }
    }
}
