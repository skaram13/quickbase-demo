using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started Program");
            PopulationStatistics populationStatistics = new PopulationStatistics();

            var populationsByCountry = populationStatistics.GetPopulationsByCountry(); 
            //Showing the final results
            foreach (var pop in populationsByCountry)
            {
                Console.WriteLine(pop.Key);
                Console.WriteLine(pop.Value);

            };
        }
    }
}
