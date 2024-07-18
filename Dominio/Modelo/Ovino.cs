using Obligatorio_Mariana_Guerra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ovino : Animal //herencia de parte de animal
    {
        public double _pesoLana { get; set; }

        private static decimal _precioXKgLana { get; set; }


        public static void EstablecerPrecio(decimal precioNuevo) //establezco el precio de la lana al precio que me dan
        {
         
            if (precioNuevo > 0) //valido que el precio q quieran poner sea mayor a 0
            {
                _precioXKgLana = precioNuevo;
            } else {
                Console.WriteLine("el precio debe ser mayor a 0");
            }
        }

        public static decimal GetPrecioLana() //obtengo el precio para poder mostrarlo
        {
           return  _precioXKgLana;
        }

        public decimal _precioXKgOvino { get; set; }
        private decimal _precioActualXKgOvino = 80; //el precio tiene q ser siempre el mismo le doy de precio 80

        public Ovino() { }

       
        public Ovino(string id, EnumSexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion,   
        decimal costoAlimentacion, double pesoActual, bool hibrido, double pesoLana, decimal precioXKgLana) : base(id, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido)
        {

            _pesoLana = pesoLana;
            _precioXKgLana = precioXKgLana;
            _precioXKgOvino = _precioActualXKgOvino;
        }

     public override decimal CalcularPrecio()
       {
            decimal total = 0;
            decimal crianza = (_costoAdquisicion + _costoAlimentacion) + (Sistema.Instancia.CalcularVacunas(this) * 200);
            decimal pesoLanaN = Convert.ToDecimal(_pesoLana);
            decimal pesoPars = Convert.ToDecimal(_pesoActual);

            total = (pesoLanaN * _precioXKgLana) + (_precioXKgOvino * pesoPars);

            if (_hibrido = true)
            {
                total = total * 0.95m;
            }
            return total - crianza;
        }



    }
}
