using System.Configuration;

namespace CodeChallenge.Modelos
{
    public class ConfiguracionBase
    {
        private const string ERROR_CONFIGURACION = "Hubo un error al obtener la configuracion. (Valor faltante: {Key})";

        public static string ObtenerConfiguracion(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
                throw new ConfigurationErrorsException(ERROR_CONFIGURACION.Replace("{Key}", key));

            return value;
        }
    }
}
