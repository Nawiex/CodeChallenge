using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Implementaciones;
using CodeChallenge.Modelos;

namespace CodeChallenge
{
    public static class Searchfight
    {
        #region Atributos

        public static List<string> ListaReportes { get; private set; }

        #endregion

        #region Servicios

        static IServicioBusqueda ServicioBusqueda;
        static IServicioGanadores ServicioGanadores;
        static IServicioReportes ServicioReportes;

        #endregion

        #region Constructores

        static Searchfight()
        {
            // Initializar dependencias
            ServicioBusqueda = new ServicioBusqueda();
            ServicioGanadores = new ServicioGanadores();
            ServicioReportes = new ServicioReportes();

            // Initialize resultados
            ListaReportes = new List<string>();
        }

        #endregion

        #region Metodos Publicos

        public static async Task CompararBuscadores(IList<string> terminos)
        {
            IList<Busqueda> searchData = await ServicioBusqueda.ObtenerResultadosBusqueda(terminos);
            IEnumerable<Ganador> searchEngineWinners = ServicioGanadores.ObtenerGanadores(searchData);
            Ganador grandWinner = ServicioGanadores.ObtenerGanador(searchData);

            ListaReportes.AddRange(ServicioReportes.ObtenerReporteBusqueda(searchData));
            ListaReportes.AddRange(ServicioReportes.ObtenerReporteGanadores(searchEngineWinners));
            ListaReportes.Add(ServicioReportes.ObtenerGanador(grandWinner));


            foreach (string item in ListaReportes) {
                Console.WriteLine(item);
            }
            Console.ReadLine();


        }

        #endregion
    }
}

