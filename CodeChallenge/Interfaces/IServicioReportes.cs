using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Modelos;

namespace CodeChallenge.Interfaces
{
    public interface IServicioReportes
    {
        IList<string> ObtenerReporteBusqueda(IList<Busqueda> dataBusqueda);
        IList<string> ObtenerReporteGanadores(IEnumerable<Ganador> ganadores);
        string ObtenerGanador(Ganador ganador);
    }
}
