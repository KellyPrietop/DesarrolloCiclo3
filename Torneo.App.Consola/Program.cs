using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        static void Main(string[] args)
        {
         int opcion = 0;
            do{
                Console.WriteLine("1.Insertar Municipio");
                Console.WriteLine("2.Insertar Director Tecnico");
                Console.WriteLine("3.Insertar Equipo");
                Console.WriteLine("4.Mostrar Municipios");
                Console.WriteLine("5.Mostrar Director Tecnico");
                Console.WriteLine("6.Mostrar Equipos");
                Console.WriteLine("0.Salir");
                Console.WriteLine("Seleccione la opcion deseada");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1 :
                        AddMunicipio();
                        break;
                    case 2 :
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break; 
                    case 4:
                        GetAllMunicipios();
                        break;  
                    case 5:
                        GetAllDTs();
                        break;    
                    case 6:
                        GetAllEquipos();
                        break;           
                }

            } while (opcion !=0) ;

        }
 //Procedimientos de Insert en la base de datos

            private static void AddMunicipio()
            {
              Console.WriteLine("Esciba el nombre del municipio");
              string nombre =Console.ReadLine();
              var municipio = new Municipio
              {
                Nombre = nombre,
              };
              _repoMunicipio.AddMunicipio(municipio);
            } 

            private static void AddDT()
            {
                Console.WriteLine("Esciba el nombre del director");
                string nombre =Console.ReadLine();
                Console.WriteLine("Esciba el documento del DT");
                string documento =Console.ReadLine();
                Console.WriteLine("Esciba el telefono del Dt");
                string telefono =Console.ReadLine();
                var directorTecnico = new DirectorTecnico
                {
                    Nombre = nombre,
                    Documento = documento,
                    Telefono = telefono
                };
                _repoDT.AddDT(directorTecnico);
            }

            private static void AddEquipo()
            {
                Console.WriteLine("Esciba el nombre del Equipo");
                string nombre =Console.ReadLine();
                Console.WriteLine("Esciba el id del Municipio");
                int idMunicipio =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba el id del DT");
                int idDT = Int32.Parse(Console.ReadLine());


                var equipo = new Equipo
                {
                    Nombre = nombre,
                };
                _repoEquipo.AddEquipo(equipo, idMunicipio,idDT);
            }
//metodos para consultas de datos
            private static void GetAllMunicipios()
            {
                foreach (var municipio in _repoMunicipio.GetAllMunicipios())
                {
                    Console.WriteLine(municipio.Id + " " + municipio.Nombre);
                }
            }

            private static void GetAllDTs()
            {
                foreach (var dt in _repoDT.GetAllDTs())
                {
                    Console.WriteLine(dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono);
                }
            }

            private static void GetAllEquipos()
            {
                foreach (var equipo in _repoEquipo.GetAllEquipos())
                {
                    Console.WriteLine(equipo.Id + " " + equipo.Nombre 
                    + " " + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre);
                }
            }



    }
}