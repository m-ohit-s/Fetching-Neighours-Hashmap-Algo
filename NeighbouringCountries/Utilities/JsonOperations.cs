using Nancy.Json;
using NeighbouringCountries.DataStructures;
using NeighbouringCountries.Interfaces;

namespace NeighbouringCountries.Utilities;

class JsonOperations : IOperations
{
    public HashMapImplementation<string, LinkedListImplementation<string>> ConvertDataToMap(dynamic mappedObject)
    {
        HashMapImplementation<string, LinkedListImplementation<string>> dictionaryOutput = new HashMapImplementation<string, LinkedListImplementation<string>>();
        foreach (var keyValuePair in mappedObject)
        {
            var dictionaryKey = keyValuePair.Key.ToString();
            LinkedListImplementation<string> dictionaryValue = new LinkedListImplementation<string>();
            for (var i = 0; i < keyValuePair.Value.Count; i++)
            {
                dictionaryValue.Enqueue(keyValuePair.Value[i]);
            }
            dictionaryOutput.Put(dictionaryKey, dictionaryValue);
        }
        return dictionaryOutput;
    }

    public dynamic ConvertStringDataToObject(string data)
    {
        var serializer = new JavaScriptSerializer();
        dynamic mappedObject = serializer.DeserializeObject(data);
        return mappedObject;
    }

    public LinkedListImplementation<string> FetchValues(HashMapImplementation<string, LinkedListImplementation<string>> dictionary, string key)
    {
        return dictionary.Get(key);
    }

    public string LoadData(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            string result = streamReader.ReadToEnd();
            return result;
        }
    }
}
