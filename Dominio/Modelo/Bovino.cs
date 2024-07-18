using Obligatorio_Mariana_Guerra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bovino : Animal  //herencia de parte de animal
    {
        public EnumAlim _tipoAlimentacion { get; set; }

        public decimal _precioXKgBovino { get; set; }


        public Bovino() { }
        public Bovino(string id, EnumSexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion,
        decimal costoAlimentacion, double pesoActual, bool hibrido, EnumAlim tipoAlimentacion, decimal precioXKgBovino) :
            base(id, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, hibrido)
        {
        
            _tipoAlimentacion = tipoAlimentacion;
            _precioXKgBovino = precioXKgBovino;
        }




        public override decimal CalcularPrecio()
        {
            decimal total = 0;
            decimal crianza = (_costoAdquisicion + _costoAlimentacion) + (Sistema.Instancia.CalcularVacunas(this) * 200);
            decimal pesoPars = Convert.ToDecimal(_pesoActual);
            
            total = (pesoPars * _precioXKgBovino);

            if (_tipoAlimentacion == EnumAlim.Grano && _sexo == EnumSexo.Macho)
            {
                total = total * 1.30m ;

            } 
           else if (_tipoAlimentacion == EnumAlim.Grano && _sexo == EnumSexo.Hembra)
            {
                total = total * 1.40m;
            }

            return total - crianza;
        }

    }
}
