using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Interfaces;
using CodeChallenge.Modelos.Bing;
using CodeChallenge.Auxiliares;
using System.Net.Http;

namespace CodeChallenge.Implementaciones
{
    public class Bing : IGestorBusqueda
    {
        #region Configuraciones

        public string Nombre => "Bing";
        private HttpClient _client { get; }

        #endregion

        #region Constructores

        public Bing()
        {
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", BingConfig.ApiKey } } };
        }

        #endregion

        #region Metodos

        public async Task<long> ObtenerResultadosAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("El parametro especificado es invalido.", nameof(query));

            string request = BingConfig.BaseUrl.Replace("{Query}", query);

            using (var response = await _client.GetAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("No se pudo procesar.");

                BingResponse results = JSONAux.Deserialize<BingResponse>(await response.Content.ReadAsStringAsync());
                return long.Parse(results.PaginasWeb.TotalPaginasEstimadas);
            }
        }

        #endregion
    }
}
