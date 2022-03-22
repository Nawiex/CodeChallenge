using System.Web.Script.Serialization;

namespace CodeChallenge.Auxiliares
{
    public static class JSONAux
    {
        public static T Deserialize<T>(this string json)
        {
            var serializador = new JavaScriptSerializer();
            return serializador.Deserialize<T>(json);
        }
    }
}
