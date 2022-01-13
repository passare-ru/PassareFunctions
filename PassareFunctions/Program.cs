using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Term2;
namespace PassareFunctions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Russian.PersonalPronoun(Russian.Perspective.Second, Russian.Number.Singular, Russian.Gender.Neuter, Russian.Case.RCase));

            Console.WriteLine(Russian.Adverb("звонко", Russian.Form.Superlative));
             
            Console.WriteLine(Russian.Adjective("красный", Russian.Number.Plural, Russian.Gender.Feminine, Russian.Case.TCase, true));

            var word = Console.ReadLine().Trim();
            if (Russian.IsAdjective(word))
            {
                Console.Write(string.Join("\n", Russian.GetAdjectiveForms(word)));
            }
            else
            {
                Console.WriteLine("Not an adjective.");
            }
            Console.ReadKey();
        }

        
    }
}
