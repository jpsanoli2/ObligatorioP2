using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VacunaAnimal     //clase asociacion
    {
        public Vacuna _vacuna { get; set; }

        public Animal _animal { get; set; }

        public DateTime _fecha { get; set; }

        public VacunaAnimal() { }

        public VacunaAnimal(Vacuna vacuna, Animal animal, DateTime fecha)
        {
            _vacuna = vacuna;
            _animal = animal;
            _fecha = fecha;
        }

        public DateTime FechaVencimiento() //calculo la fecha de vencimiento de la vacuna
        {
            return _fecha.AddYears(1); //retorno la fecha mas un año
        }

    }
}
