using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Descomentar para Depurar:
            args = new string[2];
            args[0] = "javascript";
            args[1] = "python";


            Console.WriteLine("Code Challenge : SearchFight - nawiex");
            if (args.Length == 0)
            {
                Console.WriteLine("No se especificaron terminos de busqueda. Intentar de nuevo.");
                return;
            }
            Init(args).GetAwaiter().GetResult();
        }

        static async Task Init(string[] args)
        {
            await Searchfight.CompararBuscadores(args.ToList());
            //SearchFightKernel.Reports.ForEach(report => Console.WriteLine(report));
        }
    }
}
