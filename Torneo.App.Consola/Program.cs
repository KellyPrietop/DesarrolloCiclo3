using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();
        static void Main(string[] args)
        {
         int opcion = 0;
            do{
                Console.WriteLine("1.Insertar Municipio");
                Console.WriteLine("2.Insertar Director Tecnico");
                Console.WriteLine("3.Insertar Equipo");
                Console.WriteLine("4.Insertar Posicion");
                Console.WriteLine("5.Insertar Jugador");
                Console.WriteLine("6.Insertar Partido");
                Console.WriteLine(".Mostrar Municipios");
                Console.WriteLine(".Mostrar Director Tecnico");
                Console.WriteLine(".Mostrar Equipos");
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
                        AddPosicion();
                        break;  
                    case 5:
                        AddJugador();
                        break;   
                    case 6:
                        AddPartido();
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

            private static void AddPosicion()
            {
                Console.WriteLine("Escriba el nombre de la Posicion");
                string nombre = Console.ReadLine();
                var posicion = new Posicion
                {
                    Nombre = nombre,
                };
                _repoPosicion.AddPosicion(posicion);
            }

            private static void AddJugador()
            {
                Console.WriteLine("Esciba el nombre del jugador");
                string nombre =Console.ReadLine();
                Console.WriteLine("Esciba el numero del jugador");
                int numero =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba el id del Equipo");
                int idEquipo =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba el id de la Posicion");
                int idPosicion = Int32.Parse(Console.ReadLine());


                var jugador = new Jugador
                {
                    Nombre = nombre,
                    Numero = numero,
                };
                _repoJugador.AddJugador(jugador,idEquipo,idPosicion);
            }

            private static void AddPartido()
            {
                Console.WriteLine("Esciba el id del Equipo Local");
                int idEquipoLocal =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba el id del Equipo Visitante");
                int idEquipoVisitante =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba la fecha del partido");
                string fecha =Console.ReadLine();
                DateTime myDate = DateTime.Parse(fecha);
                Console.WriteLine("Esciba el Marcador Local");
                int marcadorL =Int32.Parse(Console.ReadLine());
                Console.WriteLine("Esciba el Marcador Visitantes");
                int marcadorv =Int32.Parse(Console.ReadLine());
                
                var partido = new Partido
                {
                    FechaHora = myDate,
                    MarcadorLocal = marcadorL,
                    MarcadorVisitante = marcadorv,
                };
                _repoPartido.AddPartido(partido,idEquipoLocal,idEquipoVisitante);
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