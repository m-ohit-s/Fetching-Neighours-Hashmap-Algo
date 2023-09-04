using NeighbouringCountries.DataStructures;

namespace NeighbouringCountries.Interfaces
{
    interface INeighborsInformation
    {
        public LinkedListImplementation<string> FetchingData(string entity, string path);
        public void DisplayNeighboringData(LinkedListImplementation<string> data);
    }
}
