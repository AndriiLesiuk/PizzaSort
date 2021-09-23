using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCode
{
    class PizzasStructure
    {
        [JsonProperty("toppings")]
        public List<string> Toppings { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(Console.ReadLine());

            var list = JsonConvert.DeserializeObject<List<PizzasStructure>>(json);
            foreach (var result in list.GroupBy(z => string.Join(",", z.Toppings)).OrderByDescending(x => x.Count()).Take(20))
            {
                Console.WriteLine($"{result.Key}: {result.Count()}");
            }

        }
    }
}
