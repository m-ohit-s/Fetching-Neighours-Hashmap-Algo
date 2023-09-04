using NeighbouringCountries;
using NeighbouringCountries.Utilities;

class Program
{
    public static void Main(string[] args)
    {
        int userChoice;
        GeneratePath generatePath = new GeneratePath();
        Console.WriteLine("Enter Your choice\n1. Neighbouring Countries  \n2. Countries sharing boundary with Ocean ");
        userChoice = Convert.ToInt32(Console.ReadLine());

        if (userChoice == 1)
        {
            Console.WriteLine("Enter the country name");
            string? countryName = Console.ReadLine()!;
            BorderSharingCountries borderSharingCountries = new BorderSharingCountries();
            Console.WriteLine("\nNeighbouring Countries are : \n");
            borderSharingCountries.DisplayNeighboringData(
                borderSharingCountries.FetchingData(
                    countryName, generatePath.GetPath(@"\Datasets\json\neighboringCountryData.json")
                    )
                );
        }
        else if (userChoice == 2)
        {
            Console.WriteLine("Enter ocean name");
            string? ocean = Console.ReadLine();
            Console.WriteLine("\nBordering Countries are : \n");
            CountriesSharingOceanBorders countriesSharingOceanBorders = new CountriesSharingOceanBorders(); 
            countriesSharingOceanBorders.DisplayNeighboringData(
                countriesSharingOceanBorders.FetchingData(
                    ocean!, generatePath.GetPath(@"\Datasets\json\Oceans.json")
                    )
                );
        }
        else
        {
            Console.WriteLine("Wrong Choice");
        }
    }
}