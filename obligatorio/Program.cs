using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dominio; //lo enlazo a la biblioteca con las clases al igual que en sistema

namespace Obligatorio_Mariana_Guerra
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Sistema sistema = Sistema.Instancia;


          

            //consola:
            string opcion;
            do
            {
                Console.WriteLine("Ingrese 1 para mostrar listado de animales, ingrese 2 para ingresar una cantidad de hectareas y un numero y muestre los potreros con mas cantidad de hectareas q las proporcionadas y con capacidad maxima al numero dado, ingrese 3 para establecer el precio por kg de lana de los ovinos, ingrese 4 para dar de alta ganado bovino. Para salir ingrese 0");
                 opcion = Console.ReadLine(); //lee lo que pedimos en consola
                switch (opcion) //dependiendo de la opcion, o sea el num que escribamos en consola nos va a llevar por una opcion o por otra
                {
                    case "1":
                        Sistema.Instancia.Listado(); //nos muestra el listado de animales
                        break;
                    case "2":
                        Console.WriteLine("Escriba el numero de hectareas");
                        string EntradaNumHec = Console.ReadLine(); //necesito un numero de entrada y entro de salida para usar el tryparse
                        double SalidaNumHec;
                        while (!double.TryParse(EntradaNumHec, out SalidaNumHec)) //mientras no me deje parsearlo lo vuelvo a pedir
                        {
                            Console.WriteLine("Ingrese el dato correctamente");
                            EntradaNumHec = Console.ReadLine();
                        }
                        Console.WriteLine("Escriba el numero maximo");  //una vez que sale pido el otro numero
                        string EntradaNumMax = Console.ReadLine();
                        int SalidaNumMax;
                        while (!int.TryParse(EntradaNumMax, out SalidaNumMax))
                        {
                            Console.WriteLine("Ingrese el dato correctamente");
                            EntradaNumMax = Console.ReadLine();
                        }
                        Sistema.Instancia.ListadoPotrero(SalidaNumHec, SalidaNumMax);  //con los numeros parseados a double e int hago el metodo
                        break;
                    case "3":
                        Console.WriteLine("Escriba un precio");
                        string precioEntrada = Console.ReadLine();
                        decimal precioSalida;
                        while (!decimal.TryParse(precioEntrada, out precioSalida) || precioSalida <= 0)  //mientras no se pueda parsear sea igual o menor a 0 lo vuelvo a pedir 
                        {
                            Console.WriteLine("Ingrese el dato correctamente");
                            precioEntrada = Console.ReadLine();
                        }
                        Sistema.Instancia.EstablecerPrecio(precioSalida);
                        Console.WriteLine("El precio por kg de lana ovina ahora es de " + Sistema.Instancia.GetPrecioLana()); //pongo un ovino como ejemplo de que si cambio 
                        break;
                    case "4":
                        Console.WriteLine("Alta de bovino: Ingrese el numero de caravana alfanumerico de 8 digitos"); // pido todos los datos
                        string id = Console.ReadLine();
                     
                        EnumSexo sexo; //hago variables para guardar cada dato que me dan 
                        string raza;
                        DateTime fecha;
                        decimal costoAdquisicion;
                        decimal costoAlimentacion;
                        double pesoActual;
                         string auxHibrido;
                        bool hibrido;
                        EnumAlim tipoAlimentacion;
                        decimal precioXKgBovino;

                  
                        Console.WriteLine("Ingrese el sexo siendo macho 1 y hembra 2");

                        while (!Enum.TryParse(Console.ReadLine(), out sexo)) { //si no logra parser lo pide nuevamente, lo mismo con todos
                            Console.WriteLine("Ingrese el sexo correctamente");
                        }
                        Console.WriteLine("Ingrese la raza del bovino");
                        raza = Console.ReadLine();
                        

                        Console.WriteLine("Ingrese la fecha de nacimiento en formato AAAA/MM/DD");
                        while (!DateTime.TryParse(Console.ReadLine(), out fecha))
                        {
                            Console.WriteLine("Ingrese la fecha correctamente");
                        }


                        Console.WriteLine("Ingrese el costo de adquisicion");
                        while (!decimal.TryParse(Console.ReadLine(), out costoAdquisicion))
                        {
                            Console.WriteLine("Ingrese el costo en numeros");
                        }

                        Console.WriteLine("Ingrese el costo de alimentacion");
                        while(!decimal.TryParse(Console.ReadLine(), out costoAlimentacion))
                        {
                            Console.WriteLine("Ingrese el costo en numeros");
                        }

                        Console.WriteLine("Ingrese el peso actual");
                        while (!double.TryParse(Console.ReadLine(), out pesoActual))
                        {
                            Console.WriteLine("Ingrese el peso en numeros");
                        }



                        Console.WriteLine("Ingrese si es hibrido con 1 y si no es hibrido con 2");
                        auxHibrido = Console.ReadLine();
                        while (auxHibrido != "1" && auxHibrido != "2")
                        {
                            Console.WriteLine("Ingrese el dato correctamente");
                            auxHibrido = Console.ReadLine();
                        }


                        if(auxHibrido == "1") //dependiendo el numero que haya dado le asigno true o false
                        {
                            hibrido = true;
                        } else 
                        {
                            hibrido = false;
                        }
                        
                        Console.WriteLine("Ingrese el tipo de alimentacion 1 si es grano, 2 si es pastura");

                        while(!Enum.TryParse(Console.ReadLine(), out tipoAlimentacion))
                        {
                            Console.WriteLine("Ingrese 1 grano 2 pastura");
                        }

                        Console.WriteLine("Ingrese el precio por kg de bovino");
                        while (!decimal.TryParse(Console.ReadLine(), out precioXKgBovino))
                        {
                            Console.WriteLine("Ingrese el precio en numeros");
                        }


                      Bovino nuevoBovino =  new Bovino(id, sexo, raza, fecha, costoAdquisicion, costoAlimentacion, pesoActual, hibrido, tipoAlimentacion, precioXKgBovino); //le asigno los valores q me dieron al constructor
                     sistema.AgregarAnimal(nuevoBovino); // lo agrego al sistema(si hay algo incorrecto como el id me va a dar error y me vuelve al inicio)
                        break;
                }
            } while (opcion != "0"); //cuando sea 0 salgo
        }
    }
}
