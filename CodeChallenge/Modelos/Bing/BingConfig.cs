namespace CodeChallenge.Modelos.Bing
{
    public class BingConfig : ConfiguracionBase
    {
        public static string BaseUrl => ObtenerConfiguracion("Bing.BaseUrl");
        public static string ApiKey => ObtenerConfiguracion("Bing.ApiKey");
    }
}
