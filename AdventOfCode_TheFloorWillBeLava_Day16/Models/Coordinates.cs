﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16.Models
{
    public class Coordinates
    {
        public int? X {  get; set; }
        public int? Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinates()
        {
            
        }
    }
}
