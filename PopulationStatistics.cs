using System;
using System.Collections.Generic;

namespace Backend
{
    public class PopulationStatistics
    {
        private PopulationStatisticsRepository _repository;
        private ConcreteStatService _service;
        public PopulationStatistics()
        {
            _repository = new PopulationStatisticsRepository();
            _service = new ConcreteStatService();
        }
        public Dictionary<String, int> GetPopulationsByCountry()
        {
            // Get population data from the database		
            Dictionary<String, int> populationsByCountry = _repository.GetPopulationsByCountry();
            // Get population data from the service		
            var populationsFromService = _service.GetCountryPopulations();
            foreach (var country in populationsFromService)
            {
                //Only add population data from the service if it has not already been added from the DB
                if (!populationsByCountry.ContainsKey(country.Item1))
                {
                    populationsByCountry.Add(country.Item1, country.Item2);
                }
            }

            return populationsByCountry;
        }
    }
}