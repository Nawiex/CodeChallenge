using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Interfaces
{
    public interface IGestorBusqueda
    {
        string Nombre { get; }
        Task<long> ObtenerResultadosAsync(string query);
    }
}
