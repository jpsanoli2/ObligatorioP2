using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : IValidable  //clase padre
    {

        public string _email { get; set; }

        public string _contrasenia { get; set; }

        public string _nombre { get; set; }

        public DateTime _fechaIngreso { get; set; }

        public Empleado() { }

        public Empleado(string email, string contrasenia, string nombre, DateTime fechaIngreso)
        {

            _email = email;
            _contrasenia = contrasenia;
            _nombre = nombre;
            _fechaIngreso = fechaIngreso;
        }

        public bool EsValido() //valido el empleado
        {
            if (_contrasenia.Length <= 8) // validamos que la contraseña tenga minimo 8 caracteres
            {
                return false;
            }
            return true;
        }



    }
}
