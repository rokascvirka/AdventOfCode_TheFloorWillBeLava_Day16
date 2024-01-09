using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16.Models
{
    public class Symbol
    {
        public string Character {  get; set; }
        public Coordinates Coordinates { get; set; }

        public Symbol(string characer, Coordinates coordinates)
        {
            Character = characer;
            Coordinates = coordinates;
        }
    }
}
