using AdventOfCode_TheFloorWillBeLava_Day16.Models;
using System.Reflection;

namespace AdventOfCode_TheFloorWillBeLava_Day16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var FILE_READER = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "FakeData.txt");

            var map = FileReader.ReadDataFromFile(FILE_READER);


            LightProcessor.InitializeUpdatedMap(map);
            
            for (int i = 0;  i < map.Map.Count; i++)
            {
                string line = "";
                for (int j = 0; j < map.Map[0].Count; j++)
                {
                    line += map.UpdatedMap[i][j].Character;
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();

           // LightProcessor.Start(map, new Coordinates(0,0));

            LightProccessor_V2.Start(map, new Symbol(new Coordinates(0, 0)), DirectionEnum.MoveToRight);

            for (int i = 0; i < map.Map.Count; i++)
            {
                string line = "";
                for (int j = 0; j < map.Map[0].Count; j++)
                {
                    line += map.UpdatedMap[i][j].Character;
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("Done!");
        }
    }
}