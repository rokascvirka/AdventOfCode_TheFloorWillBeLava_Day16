using AdventOfCode_TheFloorWillBeLava_Day16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16
{
    public static class FileReader
    {
        public static LightMapModel ReadDataFromFile(string filePath)
        {
            LightMapModel model = new LightMapModel();
            using (StreamReader sr = new StreamReader(filePath))
            {
                var text = sr.ReadToEnd().Split(Environment.NewLine);
                for (int i = 0; i < text.Length; i++)
                {
                    model.Map.Add(new List<Symbol>());
                    for (int j = 0; j < text[i].Length; j++)
                    {
                        var letter = text[i][j].ToString();
                        var coords = new Coordinates(i,j);

                        model.Map[i].Add(new Symbol(letter, coords));
                    }
                }
            }

            return model;

        }
    }
}
