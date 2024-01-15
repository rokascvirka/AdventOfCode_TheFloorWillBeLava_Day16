using AdventOfCode_TheFloorWillBeLava_Day16.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16
{
    public static class LightProccessor_V2
    {
        public static readonly List<string> SPECIAL_CHARACTERS = new List<string>() { "\\", "/", "-", "|" };


        public static void Start(LightMapModel map, Symbol symbol, DirectionEnum direction)
        {
            Queue<QueueModel> symbolsQueue = new Queue<QueueModel>();
            symbolsQueue.Enqueue(new QueueModel(symbol, direction));

            while(symbolsQueue.Count > 0)
            {
                Console.WriteLine($"QUQUE COUNT: {symbolsQueue.Count}");
                var currentStep = symbolsQueue.Dequeue();
                ProcessMovement(map, currentStep, symbolsQueue);
            }
        }
        public static void ProcessMovement(LightMapModel map, QueueModel step, Queue<QueueModel> queue)
        {
            
            Console.WriteLine();
            var coords = step.Symbol.Coordinates;
            if (coords.X.HasValue)
            {
                var x = coords.X.Value;
                var y = coords.Y.Value;
                var ogSymbol = map.Map[x][y];

                if (ogSymbol.Character == ".")
                {
                    if(step.DirectionLightCameFrom == DirectionEnum.MoveToRight && !ogSymbol.IsLeftVisited)
                    {
                        MoveRight(map, coords, queue);
                        ogSymbol.IsLeftVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToLeft && !ogSymbol.IsRightVisited)
                    {
                        MoveLeft(map, coords, queue);
                        ogSymbol.IsRightVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveUp && !ogSymbol.IsBottomVisited)
                    {
                        MoveUp(map, coords, queue);
                        ogSymbol.IsBottomVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveDown && !ogSymbol.IsTopVisited)
                    {
                        MoveDown(map, coords, queue);
                        ogSymbol.IsTopVisited = true;
                    }
                }

                if (map.Map[x][y].Character == "\\")
                {
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToRight && !ogSymbol.IsLeftVisited)
                    {
                        MoveLeft(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsLeftVisited= true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToLeft && !ogSymbol.IsRightVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveUp(map, coords, queue);
                        ogSymbol.IsRightVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveUp && !ogSymbol.IsBottomVisited)
                    {
                        MoveLeft(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsBottomVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveDown && !ogSymbol.IsTopVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveUp(map, coords, queue);
                        ogSymbol.IsTopVisited = true;
                    }
                }
                if (map.Map[x][y].Character == "/")
                {
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToRight && !ogSymbol.IsLeftVisited)
                    {
                        MoveLeft(map, coords, queue);
                        MoveUp(map, coords, queue);
                        ogSymbol.IsLeftVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToLeft && !ogSymbol.IsRightVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsRightVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveUp && !ogSymbol.IsBottomVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsBottomVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveDown && !ogSymbol.IsTopVisited)
                    {
                        MoveLeft(map, coords, queue);
                        MoveUp(map, coords, queue);
                        ogSymbol.IsTopVisited = true;
                    }
                }
                if (map.Map[x][y].Character == "|")
                {
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToRight && !ogSymbol.IsLeftVisited)
                    {
                        MoveUp(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsLeftVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToLeft && !ogSymbol.IsRightVisited)
                    {
                        MoveUp(map, coords, queue);
                        MoveDown(map, coords, queue);
                        ogSymbol.IsRightVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveUp && !ogSymbol.IsBottomVisited)
                    {
                        MoveUp(map, coords, queue);
                        ogSymbol.IsBottomVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveDown && !ogSymbol.IsTopVisited)
                    {
                        MoveDown(map, coords, queue);
                        ogSymbol.IsTopVisited = true;
                    }
                }
                if (map.Map[x][y].Character == "-")
                {
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToRight && !ogSymbol.IsLeftVisited)
                    {
                        MoveRight(map, coords, queue);
                        ogSymbol.IsLeftVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveToLeft && !ogSymbol.IsRightVisited)
                    {
                        MoveRight(map, coords, queue);
                        ogSymbol.IsRightVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveUp && !ogSymbol.IsBottomVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveLeft(map, coords, queue);
                        ogSymbol.IsBottomVisited = true;
                    }
                    if (step.DirectionLightCameFrom == DirectionEnum.MoveDown && !ogSymbol.IsTopVisited)
                    {
                        MoveRight(map, coords, queue);
                        MoveLeft(map, coords, queue);
                        ogSymbol.IsTopVisited = true;
                    }
                }
            }
        }

        private static void MoveRight(LightMapModel map, Coordinates startCooridnates, Queue<QueueModel> queue)
        {
            var symbolFoundCoordinates = new Coordinates();
            var startCoordsX = startCooridnates.X.Value;
            var startCoordsY = startCooridnates.Y.Value;
            var startSymbol = map.Map[startCoordsX][startCoordsY];
            var rowLength = map.Map[0].Count;

            for(int column = startCoordsY + 1; column <  rowLength; column++)
            {
                var currentSymbol = map.Map[startCoordsX][column];
                if (startSymbol.IsRightVisited || startSymbol.IsLeftVisited)
                {
                    break;
                }

                if (SPECIAL_CHARACTERS.Any(x => x.Equals(currentSymbol.Character.ToString())))
                {
                    symbolFoundCoordinates.X = currentSymbol.Coordinates.X;
                    symbolFoundCoordinates.Y = currentSymbol.Coordinates.Y;
                    UpdateSymbolFoundToHashTag(map, symbolFoundCoordinates.X.Value, symbolFoundCoordinates.Y.Value);
                    PrintCurrentUpdatedMap(map);
                    break;
                }

                UpdateToHashTag(map, startCoordsX, column);
                PrintCurrentUpdatedMap(map);
            }
            AddToQueue(map, symbolFoundCoordinates.X, symbolFoundCoordinates.Y, queue, DirectionEnum.MoveToRight);
        }
        private static void MoveLeft(LightMapModel map, Coordinates startCooridnates, Queue<QueueModel> queue)
        {
            var symbolFoundCoordinates = new Coordinates();
            var startCoordsX = startCooridnates.X.Value;
            var startCoordsY = startCooridnates.Y.Value;
            var startSymbol = map.Map[startCoordsX][startCoordsY];
            
            for(int column = startCoordsY-1; column >= 0; column--)
            {
                var currentSymbol = map.Map[startCoordsX][column];
                if (SPECIAL_CHARACTERS.Any(x => x.Equals(currentSymbol.Character.ToString())))
                {
                    symbolFoundCoordinates.X = currentSymbol.Coordinates.X;
                    symbolFoundCoordinates.Y = currentSymbol.Coordinates.Y;
                    UpdateSymbolFoundToHashTag(map, symbolFoundCoordinates.X.Value, symbolFoundCoordinates.Y.Value);
                    PrintCurrentUpdatedMap(map);
                    break;
                }
                UpdateToHashTag(map, startCoordsX, column);
                PrintCurrentUpdatedMap(map);
            }
            AddToQueue(map, symbolFoundCoordinates.X, symbolFoundCoordinates.Y, queue, DirectionEnum.MoveToLeft);
        }
        private static void MoveDown(LightMapModel map, Coordinates startCooridnates, Queue<QueueModel> queue)
        {
            var symbolFoundCoordinates = new Coordinates();
            var startCoordsX = startCooridnates.X.Value;
            var startCoordsY = startCooridnates.Y.Value;
            var startSymbol = map.Map[startCoordsX][startCoordsY];
            var rowsCount = map.Map.Count;

            if (startCoordsX >= 0 && startCoordsX < rowsCount)
            {
                for(int row = startCoordsX + 1; row < rowsCount; row++)
                {
                    var currentSymbol = map.Map[row][startCoordsY];

                    if (SPECIAL_CHARACTERS.Any(x => x.Equals(currentSymbol.Character.ToString())))
                    {
                        symbolFoundCoordinates.X = currentSymbol.Coordinates.X;
                        symbolFoundCoordinates.Y = currentSymbol.Coordinates.Y;
                        UpdateSymbolFoundToHashTag(map, symbolFoundCoordinates.X.Value, symbolFoundCoordinates.Y.Value);
                        PrintCurrentUpdatedMap(map);
                        break;
                    }
                    
                    UpdateSymbolFoundToHashTag(map, row, startCoordsY);
                    PrintCurrentUpdatedMap(map);
                }
            }

            AddToQueue(map, symbolFoundCoordinates.X, symbolFoundCoordinates.Y, queue, DirectionEnum.MoveDown);
        }
        private static void MoveUp(LightMapModel map, Coordinates startCooridnates, Queue<QueueModel> queue)
        {
            var symbolFoundCoordinates = new Coordinates();
            var startCoordsX = startCooridnates.X.Value;
            var startCoordsY = startCooridnates.Y.Value;
            var startSymbol = map.Map[startCoordsX][startCoordsY];
            var rowsCount = map.Map.Count;
            

            if(startCoordsX <= rowsCount && startCoordsX > 0)
            {
                for(int row =  startCoordsX - 1; row >= 0; row--)
                {
                    var currentSymbol = map.Map[row][startCoordsY];
                    if (SPECIAL_CHARACTERS.Any(x => x.Equals(currentSymbol.Character.ToString())))
                    {
                        symbolFoundCoordinates.X = currentSymbol.Coordinates.X;
                        symbolFoundCoordinates.Y = currentSymbol.Coordinates.Y;
                        UpdateSymbolFoundToHashTag(map, symbolFoundCoordinates.X.Value, symbolFoundCoordinates.Y.Value);
                        PrintCurrentUpdatedMap(map);
                        break;
                    }
                    UpdateSymbolFoundToHashTag(map, row, startCoordsY);
                    PrintCurrentUpdatedMap(map);
                }
            }
            AddToQueue(map, symbolFoundCoordinates.X, symbolFoundCoordinates.Y, queue, DirectionEnum.MoveUp);
        }


        private static DirectionEnum GetDirection(Coordinates startCoordinate, Coordinates endCoordinate)
        {
            if(startCoordinate.X < endCoordinate.X && startCoordinate.Y == endCoordinate.Y)
            {
                return DirectionEnum.MoveDown;
            }
            if(startCoordinate.X > endCoordinate.X && startCoordinate.Y == endCoordinate.Y)
            {
                return DirectionEnum.MoveUp;
            }
            if(startCoordinate.X == endCoordinate.X && startCoordinate.Y < endCoordinate.Y)
            {
                return DirectionEnum.MoveToRight;
            }
            if(startCoordinate.X == endCoordinate.X && startCoordinate.Y > endCoordinate.Y)
            {
                return DirectionEnum.MoveToLeft;
            }

            return DirectionEnum.NoDirection;
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

        private static void PrintCurrentUpdatedMap(LightMapModel map)
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
        }

        private static void UpdateSymbolFoundToHashTag(LightMapModel map, int x, int y)
        {
            map.UpdatedMap[x][y].Character = "#";
        }
        private static void UpdateToHashTag(LightMapModel map, int x, int y)
        {
            map.UpdatedMap[x][y].Character = "#";
        }

        private static void AddToQueue(LightMapModel map, int? symbolFoundCoordinateX, int? symbolFoundCoordinateY, Queue<QueueModel> queue, DirectionEnum direction)
        {
            if (symbolFoundCoordinateX != null && symbolFoundCoordinateY != null)
            {
                var symbolFound = map.Map[symbolFoundCoordinateX.Value][symbolFoundCoordinateY.Value];
                if (symbolFound != null)
                {
                    queue.Enqueue(new QueueModel(symbolFound, direction));
                }
            }
        }
    }
}
