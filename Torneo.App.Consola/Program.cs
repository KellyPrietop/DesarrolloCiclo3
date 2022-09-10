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
                Console.WriteLine("Menu");
                Console.WriteLine("1.Insertar Municipio");
                Console.WriteLine("2.Insertar Director Tecnico");
                Console.WriteLine("3.Insertar Equipo");
                Console.WriteLine("4.Insertar Posicion");
                Console.WriteLine("5.Insertar Jugador");
                Console.WriteLine("6.Insertar Partido");
                Console.WriteLine("7.Mostrar Municipios");
                Console.WriteLine("8.Mostrar Director Tecnico");
                Console.WriteLine("9.Mostrar Equipos");
                Console.WriteLine("10.Mostrar Jugadores");
                Console.WriteLine("11.Mostrar Posiciones");
                Console.WriteLine("12.Mostrar Partidos");
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
                    case 7:
                        GetAllMunicipios();
                        break;   
                    case 8:
                        GetAllDTs();
                        break;   
                    case 9:
                        GetAllEquipos();
                        break;   
                    case 10:
                        GetAllJugador();
                        break;   
                    case 11:
                        GetAllPosicion();
                        break;    
                    case 12:
                        GetAllPartido();
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
                Console.WriteLine("Esciba la fecha del partido (DD-MM-YYYY)");
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
                Console.WriteLine("\t"+ "Los Municipios Son:" + "\n"); 
                foreach (var municipio in _repoMunicipio.GetAllMunicipios())
                {
                    Console.WriteLine("\t"+ municipio.Id + " " + municipio.Nombre + "\n");
                }
            }

            private static void GetAllDTs()
            {
                Console.WriteLine("\t"+ "Los Directores Tecnicos son:" + "\n");
                foreach (var dt in _repoDT.GetAllDTs())
                {
                    Console.WriteLine("\t"+ dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono + "\n");
                }
            }

            private static void GetAllEquipos()
            {
                Console.WriteLine("\t"+ "Los Equipos son :" + "\n");
                foreach (var equipo in _repoEquipo.GetAllEquipos())
                {
                    Console.WriteLine("\t"+ equipo.Id + " " + equipo.Nombre + " " + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre + "\n");
                }
            }

            private static void GetAllJugador()
            {
                Console.WriteLine("\t"+ "Los Jugadores son:" + "\n");
                foreach (var jugador in _repoJugador.GetAllJugador())
                {
                    Console.WriteLine("\t"+ jugador.Id + " " + jugador.Nombre + " " +jugador.Numero + " " + jugador.Equipo.Nombre+ " " + jugador.Posicion.Nombre + "\n");
                }
            }

            private static void GetAllPosicion()
            {
                Console.WriteLine("\t"+ "Las Posiciones  son:" + "\n");
                foreach (var posicion in _repoPosicion.GetAllPosicion())
                {
                    Console.WriteLine("\t"+ posicion.Id + " " + posicion.Nombre + "\n");
                }
            }

            private static void GetAllPartido()
            {
                Console.WriteLine("\t"+ "Los partidos  son:" + "\n");
                foreach (var partido in _repoPartido.GetAllPartido())
                {
                    Console.WriteLine("\t"+ partido.Id + " " + partido.FechaHora + " " + partido.Local.Nombre+" "+ partido.MarcadorLocal+" "+ partido.Visitante.Nombre +" " + partido.MarcadorVisitante + "\n");
                }
            }



    }
}