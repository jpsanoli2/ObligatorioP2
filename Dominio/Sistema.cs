using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
namespace Obligatorio_Mariana_Guerra
{
    public class Sistema
    {
        //patron singleton
        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }
        private Sistema()
        {
            Precarga(); //al iniciar la instancia hago la precarga de los datos
        }
        // creo las listas
        private List<Empleado> empleados = new List<Empleado>();
        private List<Animal> animales = new List<Animal>();
        private List<Tarea> tareas = new List<Tarea>();
        private List<Potrero> potreros = new List<Potrero>();
        private List<Vacuna> vacunas = new List<Vacuna>();
        private List<VacunaAnimal> vacunasAnimales = new List<VacunaAnimal>();


        public void AgregarEmpleado(Empleado empleado) //agrego el empleado
        {
           
            if (ExisteEmpleado(empleado))
            {
                throw new Exception("El usuario ya existe.");
            }
            else if (!empleado.EsValido())
            {
                throw new Exception("La contraseña debe tener 8 caracteres como minimo.");
            }
            empleados.Add(empleado);


        }

        public bool ExisteEmpleado(Empleado empleado) //metodo para verificar si existe el empleado
        {
            foreach(Empleado e in empleados)
            {
                if (empleado._email == e._email)
                {
                    return true;
                }
            }
            return false;
        }


        public void AgregarAnimal(Animal animal)//agrego animal
        {
            if(!animal.EsValido())
            {
                throw new Exception("El id debe contener 8 caracteres");
            }
            else if (ExisteAnimal(animal))
            {
                throw new Exception("El animal ya existe");
            }
            animales.Add(animal); //si no existe lo agrego a la lista

        }

        public bool ExisteAnimal(Animal animal)//metodo para verificar si existe el animal
        {
            foreach(Animal a in animales) 
            {
                if (a._id == animal._id) return true;
            }
            return false;
        }

        public void AgregarPotrero(Potrero potrero)
        {

            if (ExistePotrero(potrero)) //verifico si existe
            {
                throw new Exception("El potrero ya existe");
            }
            potreros.Add(potrero); //si no existe lo agrego a la lista

        }

        public bool ExistePotrero(Potrero potrero) //etodo para verificar si existe el potrero
        {
            foreach (Potrero p in potreros)
            {
                if(p._id == potrero._id) return true;
            }
            return false;
        }

        public void AgregarTarea(Tarea tarea)
        {
           if (ExisteTarea(tarea)) //verifico si existe
           {
               throw new Exception("La tarea ya existe");
           }
            tareas.Add(tarea); //si no existe lo agrego a la lista
        }

        public bool ExisteTarea(Tarea tarea)
        {
            foreach(Tarea t in tareas)
            {
                if (t._id == tarea._id) return true;
            }
            return false;
        }

        public void AgregarVacuna(Vacuna vacuna)
        {

            if (ExisteVacuna(vacuna)) //verifico si existe
            {
                throw new Exception("La vacuna ya existe");
            }
            vacunas.Add(vacuna); //si no existe lo agrego a la lista
        }

        public bool ExisteVacuna(Vacuna vacuna)
        {
            foreach(Vacuna v in vacunas)
            {
                if(v._nombre == vacuna._nombre) return true;
            }
            return false;
        }


    


        public void AgregarVacunaAnimal(VacunaAnimal vacunaAnimal)
        {
            if (ExisteVacunaAnimal(vacunaAnimal)) //verifico si existe
            {
                throw new Exception("La vacuna no ha vencido");
            }
            else
            {
                vacunasAnimales.Add(vacunaAnimal); //si no existe lo agrego a la lista
            }
        }
         public bool ExisteVacunaAnimal(VacunaAnimal vacunaAnimal)
      {
            foreach(VacunaAnimal v in vacunasAnimales)
            {
                if (v._animal._id == vacunaAnimal._animal._id && v._vacuna._nombre == vacunaAnimal._vacuna._nombre && vacunaAnimal.FechaVencimiento() > DateTime.Now) return true;
            }
            return false;
        }

  

        public void ListadoPotrero(double hectareas, int numero) //metodo para mostrar la lista con las condiciones debidas
        {
            foreach (var potrero in potreros)
            {
                if (potrero._cantidadHectareas > hectareas && potrero._capacidadMaxAnimales > numero)
                {
                    Console.WriteLine("Id: " + potrero._id + " Descripcion: " + potrero._descripcion + " Hectareas: " + potrero._cantidadHectareas + " Capacidad Maxima: " + potrero._capacidadMaxAnimales);
                }
            }
        }
        public void EstablecerPrecio(decimal precioNuevo)  // establezco el precio nuevo
        {
            Ovino.EstablecerPrecio(precioNuevo);
        }

     


        public Empleado GetEmpleado(string email, string contrasenia)  //metodo para buscar si ya existe un empleado con ese mail y esa contrasenia
        { 
        foreach(Empleado empleado in empleados)
                {
                if(email == empleado._email && contrasenia == empleado._contrasenia)
                {
                    return empleado;
                }
                
            }
            return null;

        }



        public Peon GetPeon(string email)
        {
            Peon actual = null;
            foreach(var p in empleados)
            {
                if (p is Peon && p._email == email)
                {
                    actual = p as Peon;
                }
            }
            return actual;
       }

        public List<Vacuna> GetVacunas()
        {
            return vacunas;
        }

        public List<Animal> GetAnimales()
        {
            return animales;
        }

        public Animal GetAnimal(string id)
        {
            Animal actual = null;
            foreach (Animal a in animales)
            {
                if (a._id == id)
                {
                    actual = a;
                }
            }
            return actual;
        }

        public Vacuna GetVacuna(string nombre)
        {
            Vacuna actual = null;
            foreach (Vacuna v in vacunas)
            {
                if (v._nombre == nombre)
                {
                    actual = v;  
                }
            }
            return actual;
        }

        public List<Tarea> GetTareas(Peon peon) //agrego las tareas que no estan completas 
        {
            List<Tarea> _tareas = new List<Tarea>();
            foreach (Tarea t in peon._tareasAsignadas)
            {
               if(!t._completa)
                
                _tareas.Add(t);
            }
            _tareas.Sort(); //devuelvo las tareas ordenadas
            return _tareas;
        }

   

        public Tarea GetTarea(int id)
        {
            Tarea actual = null;
            foreach (Tarea t in tareas)
            {
                if (t._id == id)
                {
                    actual = t;
                }
            }
            return actual;
        }

        public List<Potrero> GetPotreros()
        {
          List<Potrero> _potreros = new List<Potrero>();
            foreach (Potrero p in potreros)
            {
                if (!p.LlegoAlMax())
                {
                    _potreros.Add(p);
                    
                }
            }
            return _potreros;
        }

        public List<Tarea> GetTodasTareas()
        {
            List<Tarea> _noCompleta = new List<Tarea>();    


            foreach (Tarea t in tareas)
            {
                if (!t._completa)
                {
                     _noCompleta.Add(t);
                   
                }
            }
            
            return _noCompleta;

        }

        public List<Peon> GetPeones() { 
        
            List<Peon> _peones = new List<Peon>();
            foreach (Empleado p in empleados)
            {
                if (p is Peon peon)
                {
                    _peones.Add(peon);
                }
            }
            return _peones;
        }


        public Potrero GetPotrero(int id)
        {
            Potrero actual = null;
            foreach (Potrero p in potreros)
            {
                if (p._id == id)
                {
                    actual = p;
                }
            }
            return actual;
        }
        public List<Animal> GetAnimalesSinPotrero()
        {
            List<Animal> animalesConPotrero = new List<Animal>();
            List<Animal> animalesSinPotrero = new List<Animal>();
            foreach (Potrero p in potreros)
            {
                foreach (Animal a in p._animalesAlli)
                {
                    if (!animalesConPotrero.Contains(a))
                    {
                        animalesConPotrero.Add(a);
                    }
                }
            }
            foreach (Animal a in animales)
            {
                if (!animalesConPotrero.Contains(a))
                {
                    animalesSinPotrero.Add(a);
                }
            }
            return animalesSinPotrero;
        }

        public int CalcularVacunas(Animal animal)
        {
            int total = 0;
            foreach (VacunaAnimal va in vacunasAnimales)
            {
                if (animal._id == va._animal._id)
                {
                    total ++;
                }

            }
            return total;
        }

        public List<Potrero> GetTodosLosPotreros()
        {
            potreros.Sort(); 
            return potreros;
        }

        public List<Animal> GetAnimalesXPeso(double peso, string tipo)
        {
            List<Animal> _animales = new List<Animal>();
            foreach (Animal a in animales)
            {
                if (a._pesoActual > peso )
                {
                    if (tipo == "1" && a is Bovino || tipo == "2" && a is Ovino) 
                    {
                        _animales.Add(a);
                    }

                   
                  
                }
            }
            return _animales;

        }

        private void Precarga() //precarga de todos los datos
        {
            //datos tareas
            Tarea tarea1 = new Tarea("Vacunar ganado", new DateTime(2023, 06, 01), true, new DateTime(2023, 06, 15), "Tarea completada según lo programado.");
            Tarea tarea2 = new Tarea("Recolectar muestras de leche", new DateTime(2023, 08, 20), false, new DateTime(2023, 09, 30), "");
            Tarea tarea3 = new Tarea("Alimentar al ganado", new DateTime(2023, 05, 15), true, new DateTime(2023, 05, 30), "Ganado bien alimentado, cumpliendo con las raciones recomendadas");
            Tarea tarea4 = new Tarea("Limpiar corrales", new DateTime(2023, 07, 10), true, new DateTime(2023, 07, 25), "Corrales limpios y desinfectados para garantizar la salud del ganado.");
            Tarea tarea5 = new Tarea("Marcar terneros", new DateTime(2023, 09, 01), false, new DateTime(2023, 09, 15), "");
            Tarea tarea6 = new Tarea("Pastoreo dirigido", new DateTime(2023, 06, 25), true, new DateTime(2023, 07, 10), "Ganado pastoreado en áreas específicas para evitar la sobrecarga de pastizales.");
            Tarea tarea7 = new Tarea("Aplicar desparasitante", new DateTime(2023, 04, 20), true, new DateTime(2023, 05, 05), "Desparasitante aplicado de acuerdo con el calendario veterinario.");
            Tarea tarea8 = new Tarea("Reparar cercas", new DateTime(2023, 08, 05), false, new DateTime(2023, 08, 20), "");
            Tarea tarea9 = new Tarea("Control de plagas en el establo", new DateTime(2023, 10, 10), true, new DateTime(2023, 10, 25), "Plagas controladas mediante métodos seguros para el ganado y el medio ambiente.");
            Tarea tarea10 = new Tarea("Cosechar pasto", new DateTime(2023, 09, 20), true, new DateTime(2021, 10, 05), "Pasto cosechado y almacenado para asegurar el suministro de alimento durante la temporada seca.");
            Tarea tarea11 = new Tarea("Vacunación de ganado bovino", new DateTime(2023, 02, 06), false, new DateTime(2023, 12, 15), "Vacunar contra enfermedades comunes.");
            Tarea tarea12 = new Tarea("Revisión de la dieta del ganado ovino", new DateTime(2022, 02, 03), true, new DateTime(2022, 03, 03), "Asegurarse de que la dieta sea adecuada para la temporada.");
            Tarea tarea13 = new Tarea("Marcaje de terneros", new DateTime(2022, 11, 26), true, new DateTime(2022, 12, 24), "Aplicar las marcas correspondientes a los terneros recién nacidos.");
            Tarea tarea14 = new Tarea("Desparasitación de ovinas preñadas", new DateTime(2023, 08, 08), true, new DateTime(2023, 09, 02), "Desparasitar para prevenir complicaciones durante la gestación.");
            Tarea tarea15 = new Tarea("Pesaje de ganado bovino para registro", new DateTime(2022, 09, 16), false, new DateTime(2022, 09, 25), "Registrar los pesos individuales para llevar un control adecuado del ganado.");



            //datos bovinos
            Bovino bovino1 = new Bovino("A1B2C3D4", EnumSexo.Macho, "Angus", new DateTime(2019, 07, 12), 500, 300, 600, false, EnumAlim.Grano, 75);
            Bovino bovino2 = new Bovino("I9J1K2L3", EnumSexo.Macho, "Holstein", new DateTime(2018, 11, 30), 600, 350, 750, false, EnumAlim.Grano, 82);
            Bovino bovino3 = new Bovino("E5F6G7H8", EnumSexo.Hembra, "Hereford", new DateTime(2020, 03, 25), 450, 250, 400, true, EnumAlim.Pastura, 68);
            Bovino bovino4 = new Bovino("M4N5O6P7", EnumSexo.Hembra, "Simmental", new DateTime(2021, 05, 17), 400, 200, 550, true, EnumAlim.Pastura, 70);
            Bovino bovino5 = new Bovino("Q8R9S1T2", EnumSexo.Macho, "Charolais", new DateTime(2019, 09, 03), 550, 300, 650, false, EnumAlim.Grano, 78);
            Bovino bovino6 = new Bovino("U3V4W5X6", EnumSexo.Hembra, "Limousin", new DateTime(2020, 07, 28), 480, 270, 420, true, EnumAlim.Pastura, 65);
            Bovino bovino7 = new Bovino("Y7Z8A1B2", EnumSexo.Macho, "Angus", new DateTime(2020, 01, 10), 520, 320, 680, false, EnumAlim.Grano, 77);
            Bovino bovino8 = new Bovino("C3D4E5F6", EnumSexo.Hembra, "Hereford", new DateTime(2019, 04, 15), 430, 230, 450, true, EnumAlim.Pastura, 69);
            Bovino bovino9 = new Bovino("G7H8I9J1", EnumSexo.Macho, "Simmental", new DateTime(2021, 02, 08), 580, 330, 800, false, EnumAlim.Grano, 80);
            Bovino bovino10 = new Bovino("K2L3M4N5", EnumSexo.Hembra, "Charolais", new DateTime(2020, 10, 20), 470, 280, 610, true, EnumAlim.Pastura, 73);
            Bovino bovino11 = new Bovino("O6P7Q8R9", EnumSexo.Macho, "Limousin", new DateTime(2019, 12, 05), 510, 310, 490, false, EnumAlim.Grano, 76);
            Bovino bovino12 = new Bovino("S1T2U3V4", EnumSexo.Hembra, "Holstein", new DateTime(2021, 08, 14), 420, 220, 530, true, EnumAlim.Pastura, 71);
            Bovino bovino13 = new Bovino("W5X6Y7Z8", EnumSexo.Macho, "Simmental", new DateTime(2020, 02, 18), 540, 290, 720, false, EnumAlim.Grano, 79);
            Bovino bovino14 = new Bovino("A1B3C3D4", EnumSexo.Hembra, "Hereford", new DateTime(2019, 05, 29), 460, 260, 430, true, EnumAlim.Pastura, 67);
            Bovino bovino15 = new Bovino("E5F6N7H8", EnumSexo.Macho, "Angus", new DateTime(2021, 11, 21), 490, 300, 680, false, EnumAlim.Grano, 76);

            //datos ovinos
            Ovino ovino1 = new Ovino("1A2B3C4D", EnumSexo.Macho, "Merino", new DateTime(2020, 08, 15), 80, 40, 70, false, 2, 15);
            Ovino ovino2 = new Ovino("2B3C4D5E", EnumSexo.Hembra, "Dorper", new DateTime(2021, 02, 25), 90, 45, 55, true, 1, 20);
            Ovino ovino3 = new Ovino("3C4D5E6F", EnumSexo.Macho, "Suffolk", new DateTime(2019, 11, 10), 75, 35, 60, false, 3, 12);
            Ovino ovino4 = new Ovino("4D5E6F7G", EnumSexo.Hembra, "Lincoln", new DateTime(2020, 05, 30), 85, 38, 65, true, 2, 18);
            Ovino ovino5 = new Ovino("5E6F7G8H", EnumSexo.Macho, "Cheviot", new DateTime(2021, 09, 12), 95, 42, 50, false, 1, 22);
            Ovino ovino6 = new Ovino("6F7G8H9I", EnumSexo.Hembra, "Romney", new DateTime(2020, 03, 18), 70, 32, 55, true, 3, 10);
            Ovino ovino7 = new Ovino("7G8H9I1J", EnumSexo.Macho, "Corriedale", new DateTime(2019, 06, 22), 75, 37, 70, false, 2, 13);
            Ovino ovino8 = new Ovino("8H9I1J2K", EnumSexo.Hembra, "Shetland", new DateTime(2021, 01, 05), 80, 38, 60, true, 1, 19);
            Ovino ovino9 = new Ovino("9I1J2K3L", EnumSexo.Macho, "Rambouillet", new DateTime(2020, 07, 14), 90, 41, 55, false, 3, 11);
            Ovino ovino10 = new Ovino("1J2K3L4M", EnumSexo.Hembra, "Cotswold", new DateTime(2019, 12, 28), 85, 39, 50, true, 2, 21);
            Ovino ovino11 = new Ovino("2K3L4M5N", EnumSexo.Macho, "Jacob", new DateTime(2021, 04, 03), 75, 34, 65, false, 1, 23);
            Ovino ovino12 = new Ovino("3L4M5N6O", EnumSexo.Hembra, "Oxford Down", new DateTime(2020, 10, 17), 80, 36, 60, true, 3, 9);
            Ovino ovino13 = new Ovino("4M5N6O7P", EnumSexo.Macho, "Hampshire", new DateTime(2019, 08, 09), 85, 40, 70, false, 2, 14);
            Ovino ovino14 = new Ovino("5N6O7P8Q", EnumSexo.Macho, "Bluefaced Leicester", new DateTime(2021, 03, 14), 95, 43, 55, true, 1, 17);
            Ovino ovino15 = new Ovino("6O7P8Q9R", EnumSexo.Macho, "Targhee", new DateTime(2020, 06, 27), 70, 33, 50, false, 3, 10);

            //datos peones
            Peon peon1 = new Peon("peon1@example.com", "P3oN#1234", "Juan Pérez", new DateTime(2023, 05, 12), true, new List<Tarea> { tarea3, tarea7 });
            Peon peon2 = new Peon("peon2@example.com", "Trabajo_7890", "María López", new DateTime(2022, 11, 25), false, new List<Tarea> { tarea1, tarea9 });
            Peon peon3 = new Peon("peon3@example.com", "SeCuRiDaD$12", "Carlos Rodríguez", new DateTime(2024, 02, 08), false, new List<Tarea> { tarea4 });
            Peon peon4 = new Peon("peon4@example.com", "Trabajo_5678", "Ana Martínez", new DateTime(2023, 08, 17), true, new List<Tarea> { tarea2, tarea5 });
            Peon peon5 = new Peon("peon5@example.com", "P3oN_20242", "Luis García", new DateTime(2022, 07, 03), true, new List<Tarea> { tarea6, tarea8 });
            Peon peon6 = new Peon("peon6@example.com", "PeonSito122.", "Juan Sanchez", new DateTime(2020, 12, 01), false, new List<Tarea> { tarea15 });
            Peon peon7 = new Peon("peon7@example.com", "Peon.1Trabajito", "Lautaro Coronel", new DateTime(2022, 06, 03), false, new List<Tarea> { tarea11 });
            Peon peon8 = new Peon("peon8@example.com", "peonTrabajador.1", "Mariana Guerra", new DateTime(2020, 01, 20), true, new List<Tarea> { tarea12 });
            Peon peon9 = new Peon("peon9@example.com", "Trapeon622.", "Florencia Ceriani", new DateTime(2020, 05, 15), false, new List<Tarea> { tarea14 });
            Peon peon10 = new Peon("peon10@example.com", "trabajador122.", "Juan Martin", new DateTime(2019, 11, 17), true, new List<Tarea> { tarea15 });

            //datos potreros
            Potrero potrero1 = new Potrero("Pradera tranquila", 20, 50, new List<Animal> { bovino1, bovino3, bovino2 });
            Potrero potrero2 = new Potrero("Bosquecillo abierto", 15, 40, new List<Animal> { bovino4, bovino5, bovino6 });
            Potrero potrero3 = new Potrero("Llanura soleada", 25, 60, new List<Animal> { bovino7, bovino8, bovino9 });
            Potrero potrero4 = new Potrero("Colina verde", 18, 45, new List<Animal> { bovino10, bovino11, bovino12 });
            Potrero potrero5 = new Potrero("Valle sereno", 22, 55, new List<Animal> { bovino13, bovino14, bovino15 });
            Potrero potrero6 = new Potrero("Orilla del río", 17, 42, new List<Animal> { ovino1, ovino2, ovino3 });
            Potrero potrero7 = new Potrero("Campo amurallado", 19, 48, new List<Animal> { ovino4, ovino5, ovino6 });
            Potrero potrero8 = new Potrero("Rinconcito sombrío", 16, 40, new List<Animal> { ovino7, ovino8, ovino9 });
            Potrero potrero9 = new Potrero("Cerro elevado", 21, 52, new List<Animal> { ovino10, ovino12 });
            Potrero potrero10 = new Potrero("Prado floreciente", 23, 3, new List<Animal> { ovino13, ovino14, ovino15 });
            Potrero potrero11 = new Potrero("Campito", 22, 2, new List<Animal> { });

            //datos capataces
            Capataz capataz1 = new Capataz("capataz1@example.com", "Cap@202411", "José Martínez", new DateTime(2019, 07, 01), 3, new List<Tarea> { tarea1, tarea3, tarea5, tarea7, tarea9, tarea14, tarea15 }, new List<Peon> { peon1, peon2, peon3, peon9, peon10 });
            Capataz capataz2 = new Capataz("capataz2@example.com", "GanaCap@12311", "Ana López", new DateTime(2016, 09, 15), 2, new List<Tarea> { tarea2, tarea4, tarea6, tarea8, tarea10, tarea11, tarea12 }, new List<Peon> { peon4, peon5, peon6, peon7, peon8 });

            //datos vacunacion
            Vacuna vacuna1 = new Vacuna("BovinoGuard", "Protege contra enfermedades respiratorias comunes en el ganado bovino.", "Virus Respiratorio Sincitial Bovino (BRSV)");
            Vacuna vacuna2 = new Vacuna("Ovisheild", "Ayuda a prevenir la enterotoxemia y otras enfermedades clostridiales en ovejas.", "Clostridium perfringens");
            Vacuna vacuna3 = new Vacuna("BoviFlu", " Vacuna para prevenir la influenza bovina.", " Virus de la Influenza Bovina");
            Vacuna vacuna4 = new Vacuna("SheepGuard", "Protege contra enfermedades parasitarias y virales en ovejas.", "Parásitos internos y virus diversos");
            Vacuna vacuna5 = new Vacuna("BovinePox", "Vacuna contra la viruela bovina, una enfermedad viral que afecta la piel y las membranas mucosas de los bovinos.", "Virus de la Viruela Bovina");
            Vacuna vacuna6 = new Vacuna("OvineLepto", "Ayuda a prevenir la leptospirosis en ovejas.", "Leptospira");
            Vacuna vacuna7 = new Vacuna("BovineRotavac", "Protege contra la diarrea viral bovina causada por el rotavirus.", "Rotavirus bovino");
            Vacuna vacuna8 = new Vacuna("LambarGuard", "Vacuna para prevenir la enfermedad del cordero en el ganado ovino.", "Diversas bacterias y virus asociados a la enfermedad del cordero");
            Vacuna vacuna9 = new Vacuna("BovineBrucella", "Vacuna para prevenir la brucelosis bovina, una enfermedad bacteriana altamente contagiosa.", "Brucella abortus");
            Vacuna vacuna10 = new Vacuna("OviCoccivac", "Protege contra la coccidiosis en ovejas, una enfermedad parasitaria del tracto digestivo.", "Coccidios del género Eimeria");

            //datos vacuna animales
            VacunaAnimal vacunaAnimal1 = new VacunaAnimal(vacuna2, ovino1, new DateTime(2021, 01, 25));
            VacunaAnimal vacunaAnimal2 = new VacunaAnimal(vacuna3, bovino7, new DateTime(2021, 08, 01));
            VacunaAnimal vacunaAnimal3 = new VacunaAnimal(vacuna5, bovino2, new DateTime(2021, 11, 10));
            VacunaAnimal vacunaAnimal4 = new VacunaAnimal(vacuna10, ovino14, new DateTime(2022, 03, 30));
            VacunaAnimal vacunaAnimal5 = new VacunaAnimal(vacuna9, bovino1, new DateTime(2022, 01, 20));
            VacunaAnimal vacunaAnimal6 = new VacunaAnimal(vacuna2, ovino9, new DateTime(2021, 10, 03));
            VacunaAnimal vacunaAnimal7 = new VacunaAnimal(vacuna6, ovino15, new DateTime(2022 - 05 - 15));
            VacunaAnimal vacunaAnimal8 = new VacunaAnimal(vacuna2, ovino10, new DateTime(2022, 02, 28));
            VacunaAnimal vacunaAnimal9 = new VacunaAnimal(vacuna7, bovino15, new DateTime(2022 - 07 - 20));
            VacunaAnimal vacunaAnimal10 = new VacunaAnimal(vacuna4, ovino2, new DateTime(2022 - 04 - 05));

            //agrego al sistema los datos de precarga uno x uno
            AgregarTarea(tarea1);
            AgregarTarea(tarea2);
            AgregarTarea(tarea3);
            AgregarTarea(tarea4);
            AgregarTarea(tarea5);
            AgregarTarea(tarea6);
            AgregarTarea(tarea7);
            AgregarTarea(tarea8);
            AgregarTarea(tarea9);
            AgregarTarea(tarea10);

            AgregarAnimal(bovino1);
            AgregarAnimal(bovino2);
            AgregarAnimal(bovino3);
            AgregarAnimal(bovino4);
            AgregarAnimal(bovino5);
            AgregarAnimal(bovino6);
            AgregarAnimal(bovino7);
            AgregarAnimal(bovino8);
            AgregarAnimal(bovino9);
            AgregarAnimal(bovino10);
            AgregarAnimal(bovino11);
            AgregarAnimal(bovino12);
            AgregarAnimal(bovino13);
            AgregarAnimal(bovino14);
            AgregarAnimal(bovino15);
            AgregarAnimal(ovino1);
            AgregarAnimal(ovino2);
            AgregarAnimal(ovino3);
            AgregarAnimal(ovino4);
            AgregarAnimal(ovino5);
            AgregarAnimal(ovino6);
            AgregarAnimal(ovino7);
            AgregarAnimal(ovino8);
            AgregarAnimal(ovino9);
            AgregarAnimal(ovino10);
            AgregarAnimal(ovino11);
            AgregarAnimal(ovino12);
            AgregarAnimal(ovino13);
            AgregarAnimal(ovino14);
            AgregarAnimal(ovino15);

            AgregarEmpleado(peon1);
            AgregarEmpleado(peon2);
            AgregarEmpleado(peon3);
            AgregarEmpleado(peon4);
            AgregarEmpleado(peon5);
            AgregarEmpleado(peon6);
            AgregarEmpleado(peon7);
            AgregarEmpleado(peon8);
            AgregarEmpleado(peon9);
            AgregarEmpleado(peon10);

            AgregarEmpleado(capataz1);
            AgregarEmpleado(capataz2);

            AgregarPotrero(potrero1);
            AgregarPotrero(potrero2);
            AgregarPotrero(potrero3);
            AgregarPotrero(potrero4);
            AgregarPotrero(potrero5);
            AgregarPotrero(potrero6);
            AgregarPotrero(potrero7);
            AgregarPotrero(potrero8);
            AgregarPotrero(potrero9);
            AgregarPotrero(potrero10);
            AgregarPotrero(potrero11);

            AgregarVacuna(vacuna1);
            AgregarVacuna(vacuna2);
            AgregarVacuna(vacuna3);
            AgregarVacuna(vacuna4);
            AgregarVacuna(vacuna5);
            AgregarVacuna(vacuna6);
            AgregarVacuna(vacuna7);
            AgregarVacuna(vacuna8);
            AgregarVacuna(vacuna9);
            AgregarVacuna(vacuna10);

            AgregarVacunaAnimal(vacunaAnimal1);
            AgregarVacunaAnimal(vacunaAnimal2);
            AgregarVacunaAnimal(vacunaAnimal3);
            AgregarVacunaAnimal(vacunaAnimal4);
            AgregarVacunaAnimal(vacunaAnimal5);
            AgregarVacunaAnimal(vacunaAnimal6);
            AgregarVacunaAnimal(vacunaAnimal7);
            AgregarVacunaAnimal(vacunaAnimal8);
            AgregarVacunaAnimal(vacunaAnimal9);
            AgregarVacunaAnimal(vacunaAnimal10);

        }



    }
}
