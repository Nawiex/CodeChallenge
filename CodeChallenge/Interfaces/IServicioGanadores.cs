using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Modelos;

namespace CodeChallenge.Interfaces
{
    public interface IServicioGanadores
    {
        IEnumerable<Ganador> ObtenerGanadores(IList<Busqueda> searchData);
        Ganador ObtenerGanador(IList<Busqueda> searchData);
    }
}
