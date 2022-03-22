using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Modelos.Google;
using CodeChallenge.Auxiliares;
using System.Net.Http;

namespace CodeChallenge.Implementaciones
{
    public class Google : IGestorBusqueda
    {
        #region Configuraciones

        public string Nombre => "Google";
        private HttpClient _client { get; }

        #endregion

        #region Constructores

        public Google()
        {
            _client = new HttpClient();
        }

        #endregion

        #region Metodos
        public async Task<long> ObtenerResultadosAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("El parametro especificado es invalido.", nameof(query));

            string request = GoogleConfig.BaseUrl.Replace("{Key}", GoogleConfig.ApiKey)
                .Replace("{Context}", GoogleConfig.ContextId)
                .Replace("{Query}", query);

            using (var response = await _client.GetAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("No se pudo procesar.");

                GoogleResponse resultados = JSONAux.Deserialize<GoogleResponse>(await response.Content.ReadAsStringAsync());
                return long.Parse(resultados.informacionBusqueda.Totales);
            }
        }
        #endregion
    }
}
