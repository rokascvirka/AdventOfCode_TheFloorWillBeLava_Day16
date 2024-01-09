using System.Reflection;

namespace AdventOfCode_TheFloorWillBeLava_Day16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var FILE_READER = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "FakeData.txt");

            var map = FileReader.ReadDataFromFile(FILE_READER);

            Console.WriteLine("Done!");
        }
    }
}