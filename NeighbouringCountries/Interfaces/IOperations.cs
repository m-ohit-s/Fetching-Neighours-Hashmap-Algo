using NeighbouringCountries.DataStructures;

namespace NeighbouringCountries.Interfaces
{
    interface IOperations
    {
        public string LoadData(string path);
        public dynamic ConvertStringDataToObject(string data);
        public HashMapImplementation<string, LinkedListImplementation<string>> ConvertDataToMap(dynamic mappedObject);
        public LinkedListImplementation<string> FetchValues(HashMapImplementation<string, LinkedListImplementation<string>> dictionary, string key);
    }
}
