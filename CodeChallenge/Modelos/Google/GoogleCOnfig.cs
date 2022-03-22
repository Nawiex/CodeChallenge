namespace CodeChallenge.Modelos.Google
{
    public class GoogleConfig : ConfiguracionBase
    {
        public static string BaseUrl => ObtenerConfiguracion("Google.BaseUrl");
        public static string ApiKey => ObtenerConfiguracion("Google.ApiKey");
        public static string ContextId => ObtenerConfiguracion("Google.ContextId");
    }
}
