using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tarea : IComparable<Tarea>
    {
        public int _id { get; set; }

        public static int s_contador = 0;

        public string _descripcion { get; set; }

        public DateTime _fechaRealizacion { get; set; }

        public bool _completa { get; set; }

        public DateTime _fechaCierre { get; set; }

        public string _comentarioPeon { get; set; }

        public Tarea() {
            _id = s_contador++;
        }

        public Tarea(string descripcion, DateTime fechaRealizacion, bool completa, DateTime fechaCierre,
            string comentarioPeon)
        {

            _id = s_contador++;
            _descripcion = descripcion;
            _fechaRealizacion = fechaRealizacion;
            _completa = completa;
            _fechaCierre = fechaCierre;

        }


        public int CompareTo(Tarea obj) //ordenamos las tareas por fecha pactada
        {
            return _fechaCierre.CompareTo(obj._fechaCierre);

        }

        public void FinalizarTarea()
        {
            if (string.IsNullOrEmpty(_comentarioPeon))
            {
                throw new Exception("Debe ingresar un comentario");
            }
        }

        public override string ToString()
        {
            return $"La tarea es: {_id} completa: {_completa}";
        }
        public bool EsValido()
        {
            
            if(string.IsNullOrEmpty(_descripcion) || _fechaRealizacion == DateTime.MinValue || _fechaCierre == DateTime.MinValue)
            {
                return false ;
            }
            return true ;
        }
     
    }
}
