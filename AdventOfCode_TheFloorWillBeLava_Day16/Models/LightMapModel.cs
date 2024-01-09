using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16.Models
{
    public  class LightMapModel
    {
        public List<List<Symbol>> Map {  get; set; }
        public List<List<Symbol>> UpdatedMap { get; set; }

        public int TilesCounted { get; set; }

        public LightMapModel()
        {
            Map = new List<List<Symbol>>();
        }
    }
}
