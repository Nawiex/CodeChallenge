using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Modelos;

namespace CodeChallenge.Interfaces
{
    public interface IServicioBusqueda
    {
        Task<IList<Busqueda>> ObtenerResultadosBusqueda(IList<string> terminos);
    }
}
