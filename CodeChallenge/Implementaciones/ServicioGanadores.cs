using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Modelos;
using CodeChallenge.Auxiliares;

namespace CodeChallenge.Implementaciones
{
    public class ServicioGanadores : IServicioGanadores
    {
        public Ganador ObtenerGanador(IList<Busqueda> dataBusqueda)
        {
            if (dataBusqueda == null || dataBusqueda.Count() == 0)
                throw new ArgumentException("El argumento especificado es invalido.", nameof(dataBusqueda));

            Busqueda ganador = dataBusqueda.ObtenerMaximo(item => item.Resultados);
            return new Ganador() { MotorBusqueda = ganador.Buscador, Termino = ganador.Terminos };
        }

        public IEnumerable<Ganador> ObtenerGanadores(IList<Busqueda> dataBusqueda)
        {
            if (dataBusqueda == null || dataBusqueda.Count() == 0)
                throw new ArgumentException("El argumento especificado es invalido.", nameof(dataBusqueda));

            IEnumerable<Ganador> buscadores = dataBusqueda.GroupBy(data => data.Buscador,
                resultado => resultado, (buscador, resultados) => new Ganador
                {
                    MotorBusqueda = buscador,
                    Termino = resultados.ObtenerMaximo(item => item.Resultados).Terminos
                });

            return buscadores;
        }
    }
}
