using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Animal : IValidable//clase padre abstracta
    {
        public string _id { get; set; }

        public EnumSexo _sexo { get; set; }

        public string _raza { get; set; }

        public DateTime _fechaNacimiento { get; set; }

        public decimal _costoAdquisicion { get; set; }

        public decimal _costoAlimentacion { get; set; }

        public double _pesoActual { get; set; }

        public bool _hibrido { get; set; }


        public Animal() { }

        public Animal(string id, EnumSexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion,
            decimal costoAlimentacion, double pesoActual, bool hibrido)
        {

            _id = id;
            _sexo = sexo;
            _raza = raza;
            _fechaNacimiento = fechaNacimiento;
            _costoAdquisicion = costoAdquisicion;
            _costoAlimentacion = costoAlimentacion;
            _pesoActual = pesoActual;
            _hibrido = hibrido;
        }

        public bool EsValido()
        {
            if (_id.Length != 8)
            {
                
                return false;
            }
            return true;
        }

        public int CalcularEdad(DateTime fechaActual)
        {

            int edadMeses = ((fechaActual.Year - _fechaNacimiento.Year) * 12) + fechaActual.Month - _fechaNacimiento.Month; //calculo los meses de edad

            if (fechaActual.Day < _fechaNacimiento.Day) //me aseguro que si el mes no esta completo no se lo sumo a la edad
            {
                edadMeses--;
            }

            return edadMeses;
        }

        public bool PuedeVacunarse() //metodo para saber si tiene mas de 3 meses de edad el animal y se puede vacunar
        {

            if (CalcularEdad(DateTime.Now) > 3)
            {
                return true;
            }
            return false;
        }

        public abstract decimal CalcularPrecio();


        public override string ToString()
        {
            return ($"Id: {_id}, Raza: {_raza}, Peso: {_pesoActual}");
        }
    }
}
