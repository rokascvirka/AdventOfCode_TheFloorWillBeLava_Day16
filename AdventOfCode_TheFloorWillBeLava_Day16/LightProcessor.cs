using AdventOfCode_TheFloorWillBeLava_Day16.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16
{
    public static class LightProcessor
    {

        public static readonly List<string> CHARACTERS = new List<string>() { "\\", "/", "-", "|" };


        public static void UpdateLightMap(LightMapModel map, string direction)
        {
            var start = new Coordinates(0, 0);
            var IsThereAnyPlaceToMove = true;


            List<Coordinates> currentDirections = new List<Coordinates>();
            
        }

        public static void Start(LightMapModel map, Coordinates coordinates)
        {
            for (int i = 0; i < map.Map.Count; i++)
            {
                string line = "";
                for (int j = 0; j < map.Map[0].Count; j++)
                {
                    line += map.UpdatedMap[i][j].Character;
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
            if (coordinates.X.HasValue || coordinates.Y.HasValue)
            {
                var side = GetDirection(coordinates, coordinates);

                if (map.Map[coordinates.X.Value][coordinates.Y.Value].Character == ".")
                {
                    if (side == "right")
                    {
                        MoveRight(map, coordinates);
                    }
                    if (side == "left")
                    {
                        MoveLeft(map, coordinates);
                    }
                    if (side == "up")
                    {
                        MoveUp(map, coordinates);
                    }
                    if (side == "down")
                    {
                        MoveDown(map, coordinates);
                    }
                }
                else if (map.Map[coordinates.X.Value][coordinates.Y.Value].Character == "\\")
                {
                    if (side == "right")
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited = true;
                        MoveLeft(map, coordinates);
                        MoveDown(map, coordinates);
                        
                    }
                    if (side == "left")
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited = true;
                        MoveUp(map, coordinates);
                        MoveLeft(map, coordinates);
                        
                    }
                    if(side == "up")
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited = true;
                        MoveRight(map, coordinates);
                        MoveDown(map, coordinates);
                    }
                    if ((side == "down"))
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited = true;
                        MoveUp(map, coordinates);
                        MoveLeft(map, coordinates);
                    }
                }
                else if (map.Map[coordinates.X.Value][coordinates.Y.Value].Character == "/")
                {
                    if (side == "right")
                    {
                        
                        MoveUp(map, coordinates);
                        MoveLeft(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited = true;
                    }
                    if (side == "left")
                    {
                        MoveRight(map, coordinates);
                        MoveDown(map, coordinates);
                        
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited = true;
                    }
                    if (side == "up")
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited = true;
                        MoveLeft(map, coordinates);
                        MoveDown(map, coordinates);
                    }
                    if ((side == "down"))
                    {
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited = true;
                        MoveUp(map, coordinates);
                        MoveRight(map, coordinates);
                    }
                }
                else if ((map.Map[coordinates.X.Value][coordinates.Y.Value].Character == "|"))
                {
                    if (side == "right")
                    {
                        MoveUp(map, coordinates);
                        MoveDown(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited = true;
                    }
                    if (side == "left")
                    {
                        MoveUp(map, coordinates);
                        MoveDown(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited = true;
                    }
                    if (side == "up")
                    {
                        MoveUp(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsBottomVisited = true;
                    }
                    if (side == "down")
                    {
                        MoveDown(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsTopVisited = true;

                    }
                }
                else if (map.Map[coordinates.X.Value][coordinates.Y.Value].Character == "-")
                {
                    if (side == "right")
                    {
                        MoveRight(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsLeftVisited= true;
                    }
                    if (side == "left")
                    {
                        MoveLeft(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsRightVisited= true;
                    }
                    if (side == "up")
                    {
                        MoveLeft(map, coordinates);
                        MoveRight(map, coordinates);
                        
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsBottomVisited = true;
                    }
                    if (side == "down")
                    {
                        MoveLeft(map, coordinates);
                        MoveRight(map, coordinates);
                        map.Map[coordinates.X.Value][coordinates.Y.Value].IsTopVisited = true;
                    }
                }
            }

           
        }

        private static void MoveDown(LightMapModel map, Coordinates startCoordinates)
        {
            var symbolCoordinates = new Coordinates();
            for (int i = startCoordinates.X.Value + 1; i < map.Map.Count; i++)
            {
                var symbol = map.Map[startCoordinates.X.Value][startCoordinates.Y.Value];
                if (symbol.IsTopVisited || symbol.IsRightVisited )
                {
                    break;
                }
                
                if (CHARACTERS.Any(x => x.Equals(map.Map[i][startCoordinates.Y.Value].Character.ToString())))
                {
                    var cords = new Coordinates(i, startCoordinates.Y.Value);
                    symbolCoordinates = cords;
                    map.UpdatedMap[startCoordinates.X.Value][startCoordinates.Y.Value].Character = "#";
                    break;
                }
                map.UpdatedMap[i][startCoordinates.Y.Value].Character = "#";
            }

            if (symbolCoordinates.X.HasValue)
            {
                Start(map, symbolCoordinates);
            }

            //return symbolCoordinates;
        }

        private static void MoveUp(LightMapModel map,Coordinates startCoordinates)
        {
            var symbolCoordinates = new Coordinates();
            if(startCoordinates.X > 0)
            {
                for (int i = startCoordinates.X.Value - 1; i > 0; i--)
                {
                    var symbol = map.Map[startCoordinates.X.Value][startCoordinates.Y.Value];
                    if (symbol.IsLeftVisited || symbol.IsBottomVisited)
                    {
                        break;
                    }
                    if (CHARACTERS.Any(x => x.Equals(map.Map[i][startCoordinates.Y.Value].Character.ToString())))
                    {
                        var cords = new Coordinates(i, startCoordinates.Y.Value);
                        symbolCoordinates = cords;
                        map.UpdatedMap[startCoordinates.X.Value][startCoordinates.Y.Value].Character = "#";
                        break;
                    }
                    map.UpdatedMap[i][startCoordinates.Y.Value].Character = "#";
                }
            }
            if (symbolCoordinates.X.HasValue)
            {
                Start(map, symbolCoordinates);
            }
        }
        private static void MoveRight(LightMapModel map, Coordinates startCoordinates)
        {
            var symbolCoordinates = new Coordinates();
            for( int column = startCoordinates.Y.Value + 1; column < map.Map[startCoordinates.X.Value].Count; column++)
            {
                var symbol = map.Map[startCoordinates.X.Value][startCoordinates.Y.Value];
                if (symbol.IsRightVisited || symbol.IsLeftVisited)
                {
                    break;
                }
                if (CHARACTERS.Any(x => x.Equals(map.Map[startCoordinates.X.Value][column].Character.ToString())))
                {
                    var cords = new Coordinates(startCoordinates.X.Value, column);
                    symbolCoordinates = cords;
                    map.UpdatedMap[startCoordinates.X.Value][startCoordinates.Y.Value].Character = "#";
                    break;
                }

                map.UpdatedMap[startCoordinates.X.Value][column].Character = "#";
            }
            if (symbolCoordinates.X.HasValue)
            {
                Start(map, symbolCoordinates);
            }
        }

        private static void MoveLeft(LightMapModel map, Coordinates startCoordinates)
        {
            var symbolCoordinates = new Coordinates();
            for (int column = startCoordinates.Y.Value - 1; column > 0; column--)
            {
                var symbol = map.Map[startCoordinates.X.Value][startCoordinates.Y.Value];
                if (symbol.IsRightVisited || symbol.IsLeftVisited || symbol.IsTopVisited || symbol.IsBottomVisited)
                {
                    break;
                }
                if (CHARACTERS.Any(x => x.Equals(map.Map[startCoordinates.X.Value][column].Character.ToString())))
                {
                    var cords = new Coordinates(startCoordinates.X.Value, column);
                    symbolCoordinates = cords;
                    map.UpdatedMap[startCoordinates.X.Value][startCoordinates.Y.Value].Character = "#";
                    break;
                }

                map.UpdatedMap[startCoordinates.X.Value][column].Character = "#";
            }
            if (symbolCoordinates.X.HasValue)
            {
                Start(map, symbolCoordinates);
            }
        }

        private static string GetDirection(Coordinates startCoord, Coordinates symbolCoords)
        {
            if (startCoord.X == symbolCoords.X && startCoord.Y == symbolCoords.Y)
            {
                return "right";
            }
            if (startCoord.X < symbolCoords.X && symbolCoords.Y == symbolCoords.Y)
            {
                return "down";
            }
            if (startCoord.X > symbolCoords.X && symbolCoords.Y == symbolCoords.Y)
            {
                return "up";
            }
            if (startCoord.X == symbolCoords.X && startCoord.Y < symbolCoords.Y)
            {
                return "rigth";
            }
            if (startCoord.X == symbolCoords.X && symbolCoords.Y > symbolCoords.Y)
            {
                return "left";
            }
            return "fail";
        }

        public static void InitializeUpdatedMap(LightMapModel map)
        {
            var rows = map.Map.Count;
            var columns = map.Map[0].Count;

            for (var i = 0; i < rows; i++)
            {
                List<Symbol> list = new List<Symbol>();
                for (var j = 0; j < columns; j++)
                {
                    list.Add(new Symbol(".", new Coordinates(i, j)));
                }
                map.UpdatedMap.Add(list);
            }
        }
    }
}
