using System;
using System.Collections.Generic;

namespace CodeChallenge.Auxiliares
{
    public static class ExtensionesEnumerables
    {
        public static T ObtenerMaximo<T>(this IEnumerable<T> fuente, Func<T, long> func)
        {
            if (fuente == null)
                throw new ArgumentException("El paramentro no puede ser null.", nameof(fuente));

            using (var enumerador = fuente.GetEnumerator())
            {
                if (!enumerador.MoveNext())
                    throw new ArgumentException("No se puede obtener el siguiente enumerator del parametro especificado.", nameof(fuente));

                long maximoActual = func(enumerador.Current);
                T itemMaximo = enumerador.Current;

                while (enumerador.MoveNext())
                {
                    var enumeradorEvaluado = func(enumerador.Current);

                    if (maximoActual < enumeradorEvaluado)
                    {
                        maximoActual = enumeradorEvaluado;
                        itemMaximo = enumerador.Current;
                    }
                }
                return itemMaximo;
            }
        }
    }
}
