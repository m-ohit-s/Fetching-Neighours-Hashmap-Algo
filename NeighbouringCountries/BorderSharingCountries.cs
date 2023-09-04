using NeighbouringCountries.DataStructures;
using NeighbouringCountries.Interfaces;
using NeighbouringCountries.Utilities;

namespace NeighbouringCountries
{
    class BorderSharingCountries : INeighborsInformation
    {
        JsonOperations jsonOperations = new JsonOperations();

        public void DisplayNeighboringData(LinkedListImplementation<string> borderingCountries)
        {
  
            foreach (var countryInBorderingCoutries in borderingCountries)
            {
                Console.WriteLine(countryInBorderingCoutries);
            }
        }

        public LinkedListImplementation<string> FetchingData(string entity, string path)
        {
            HashMapImplementation<string, LinkedListImplementation<string>>? dictionaryJsonData = 
                jsonOperations.ConvertDataToMap(
                    jsonOperations.ConvertStringDataToObject(
                        jsonOperations.LoadData(
                            path
                            )
                        )
                    );
            var borderingCountries = jsonOperations.FetchValues(dictionaryJsonData!, entity);
            return borderingCountries;
        }
    }
}
