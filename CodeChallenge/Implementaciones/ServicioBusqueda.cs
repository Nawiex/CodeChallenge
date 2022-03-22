using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Modelos;
using System.Reflection;

namespace CodeChallenge.Implementaciones
{
    class ServicioBusqueda : IServicioBusqueda
    {
        #region Atributos

        private IList<IGestorBusqueda> _gestoresBusqueda;

        #endregion

        #region Constructores

        public ServicioBusqueda()
        {
            _gestoresBusqueda = ObtenerGestoresBusqueda();
        }

        #endregion

        #region Metodos Privados

        private IList<IGestorBusqueda> ObtenerGestoresBusqueda()
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("CodeChallenge"));

            return assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(IGestorBusqueda).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as IGestorBusqueda).ToList();
        }

        #endregion

        #region Metodos Publicos

        public async Task<IList<Busqueda>> ObtenerResultadosBusqueda(IList<string> terminos)
        {
            if (terminos == null || terminos.Count() == 0)
                throw new ArgumentException("El argumento especificado es invalido.", nameof(terminos));

            IList<Busqueda> resultados = new List<Busqueda>();

            foreach (IGestorBusqueda gestor in _gestoresBusqueda)
            {
                foreach (string termino in terminos)
                {
                    resultados.Add(new Busqueda
                    {
                        Buscador = gestor.Nombre,
                        Terminos = termino,
                        Resultados = await gestor.ObtenerResultadosAsync(termino)
                    });
                }
            }

            return resultados;
        }

        #endregion
    }
}
