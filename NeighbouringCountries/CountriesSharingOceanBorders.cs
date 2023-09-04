using NeighbouringCountries.DataStructures;
using NeighbouringCountries.Interfaces;
using NeighbouringCountries.Utilities;

namespace NeighbouringCountries
{
    class CountriesSharingOceanBorders: INeighborsInformation
    {
        JsonOperations jsonOperations = new JsonOperations();
        public void DisplayNeighboringData(LinkedListImplementation<string> oceanConnectingCountries)
        {
            foreach (var country in oceanConnectingCountries)
            {
                Console.WriteLine(country);
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
            var oceanConnectingCountries = jsonOperations.FetchValues(
                dictionaryJsonData!, entity
                );
            return oceanConnectingCountries;
        }
    }
}
