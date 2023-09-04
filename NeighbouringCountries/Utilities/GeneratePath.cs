
using NeighbouringCountries.Interfaces;

namespace NeighbouringCountries.Utilities;

class GeneratePath : IPathOperations
{
    public string GetPath(string path)
    {
        string workingDirectory = Environment.CurrentDirectory;
        return Directory.GetParent(workingDirectory).Parent.Parent.FullName + path;
    }
}
