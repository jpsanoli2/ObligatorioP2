namespace ObligatorioMvc.ViewModels
{
    public class PeonTareaView
    {
        public IEnumerable<Dominio.Peon> Peones { get; set; }

        public IEnumerable<Dominio.Tarea> Tareas { get; set; }
    }
}
