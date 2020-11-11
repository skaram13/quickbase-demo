using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Backend
{
    public class PopulationStatisticsRepository
    {
        private static String GET_POPULATIONS_BY_COUNTRY = 
            "SELECT Country.CountryName, SUM(City.Population) as Population FROM Country " +
            "INNER JOIN State ON Country.CountryId = State.CountryId " +
            "INNER JOIN City ON City.StateId = State.StateId " +
            "GROUP BY Country.CountryName";
        
        public Dictionary<string, int> GetPopulationsByCountry()
        {
            Dictionary<string, int> countriesPopulation = new Dictionary<string, int>();
            SqliteDbManager DbManager = new SqliteDbManager();
            DbConnection conn = DbManager.getConnection();
            
            // Check for valid DbConnection.
            if (conn != null)
            {
                using (conn)
                {
                    try
                    {
                        // Create the query.
                        DbCommand command = conn.CreateCommand();
                        command.CommandText = GET_POPULATIONS_BY_COUNTRY;
                        command.CommandType = CommandType.Text;

                        // Retrieve the data.
                        DbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //Create a Dictionary with the Countries and their populations
                            countriesPopulation.Add(reader[0].ToString(), Convert.ToInt32(reader[1]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DB Manager Exception.Message: {0}", ex.Message);
                    }
                }
            }

            return countriesPopulation;
        }
    }
}
