using Nancy.Json;
using NeighbouringCountries.DataStructures;

class Program
{
    public static void Main(string[] args)
    {
        int userChoice;
        Console.WriteLine("Enter Your choice\n1. Neighbouring Countries  \n2. Countries sharing boundary with Ocean ");
        userChoice = Convert.ToInt32(Console.ReadLine());

        if (userChoice == 1)
        {
            Console.WriteLine("Enter the country name");
            string? countryName = Console.ReadLine()!;
            CountriesSharingBorders neigbouringCoutryBorders = new CountriesSharingBorders();
            Console.WriteLine("\nNeighbouring Countries are : \n");
            neigbouringCoutryBorders.DisplayNeighboringCountries(countryName);
        }
        else if (userChoice == 2)
        {
            Console.WriteLine("Enter ocean name");
            string? ocean = Console.ReadLine();
            Console.WriteLine("\nBordering Countries are : \n");
            OceanNeighbouringCountries neighboringOceanBorders = new OceanNeighbouringCountries();
            neighboringOceanBorders.displayOceanBoundaries(ocean!);
        }
        else
        {
            Console.WriteLine("Wrong Choice");
        }
    }
}

class Operations
{
    protected static string LoadJson(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            string result = streamReader.ReadToEnd();
            return result;
        }
    }

    protected static HashMapImplementation<string, LinkedListImplementation<string>> ConvertJsonToDictionary(string json)
    {

        HashMapImplementation<string, LinkedListImplementation<string>> dictionaryOutput = new HashMapImplementation<string, LinkedListImplementation<string>>();

        var serializer = new JavaScriptSerializer();

        dynamic mappedObject = serializer.DeserializeObject(json);

        foreach(var keyValuePair in mappedObject)
        {
            var dictionaryKey = keyValuePair.Key.ToString();
            LinkedListImplementation<string> dictionaryValue = new LinkedListImplementation<string>();
            for(var i = 0; i < keyValuePair.Value.Count; i++)
            {
                dictionaryValue.Enqueue(keyValuePair.Value[i]);
            }
            dictionaryOutput.Put(dictionaryKey, dictionaryValue);
        }
        return dictionaryOutput;
    }

    protected static LinkedListImplementation<string> FetchValues(HashMapImplementation<string, LinkedListImplementation<string>> jsonDictionary, string key)
    {
        return jsonDictionary.Get(key);
    }

    public string getCurrentDirectory()
    {
        string workingDirectory = Environment.CurrentDirectory;
        return Directory.GetParent(workingDirectory).Parent.Parent.FullName;
    }
}


class CountriesSharingBorders : Operations
{
    public void DisplayNeighboringCountries(string country)
    {
        HashMapImplementation<string, LinkedListImplementation<string>>? dictionaryJsonData = ConvertJsonToDictionary(LoadJson(getCurrentDirectory() + @"\Datasets\json\neighboringCountryData.json"));
        var borderingCountries = FetchValues(dictionaryJsonData!, country);
        foreach (var countryInBorderingCoutries in borderingCountries)
        {
            Console.WriteLine(countryInBorderingCoutries);
        }
    }
}

class OceanNeighbouringCountries : Operations
{
    public void displayOceanBoundaries(string ocean)
    {
        HashMapImplementation<string, LinkedListImplementation<string>>? dictionaryJsonData = ConvertJsonToDictionary(LoadJson(getCurrentDirectory() + @"\Datasets\json\Oceans.json"));
        var oceanConnectingCountries = FetchValues(dictionaryJsonData!, ocean);
        foreach (var country in oceanConnectingCountries)
        {
            Console.WriteLine(country);
        }
    }
}