namespace ObligatorioMvc.ViewModels
{
    public class RegistroVacunasView
    {
        public IEnumerable<Dominio.Vacuna> Vacunas { get; set; }
        public IEnumerable<Dominio.Animal> Animales { get; set; }

    }
}
