using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Modelos;

namespace CodeChallenge.Implementaciones
{
    public class ServicioReportes : IServicioReportes
    {
        #region Constantes

        public const string GANADOR_TITULO = "Ganador: ";

        #endregion

        #region Metodos Publicos

        public IList<string> ObtenerReporteBusqueda(IList<Busqueda> dataBusqueda)
        {
            if (dataBusqueda == null || dataBusqueda.Count == 0)
                throw new ArgumentException("El argumento especifcado es invalido", nameof(dataBusqueda));

            return dataBusqueda.GroupBy(item => item.Terminos)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.Buscador}: {item.Resultados}"))}")
                .ToList();
        }

        public IList<string> ObtenerReporteGanadores(IEnumerable<Ganador> ganadores)
        {
            if (ganadores == null || ganadores.Count() == 0)
                throw new ArgumentException("El paramentro especificado es invalido", nameof(ganadores));

            List<string> resultados = new List<string>();

            foreach (Ganador ganador in ganadores)
            {
                StringBuilder ganadorBuilder = new StringBuilder();
                ganadorBuilder.Append(ganador.MotorBusqueda + " ganador : ");
                ganadorBuilder.Append(ganador.Termino);
                resultados.Add(ganadorBuilder.ToString());
            }

            return resultados;
        }

        public string ObtenerGanador(Ganador ganador)
        {
            if (ganador == null)
                throw new ArgumentException("El parametro especificado es invalido", nameof(ganador));

            StringBuilder ganadorBuilder = new StringBuilder();
            ganadorBuilder.Append(GANADOR_TITULO);
            ganadorBuilder.Append(ganador.MotorBusqueda);
            return ganadorBuilder.ToString();
        }

        #endregion
    }
}
