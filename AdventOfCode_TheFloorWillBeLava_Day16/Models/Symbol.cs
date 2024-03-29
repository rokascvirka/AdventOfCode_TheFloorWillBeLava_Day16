﻿using System;
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

        public bool IsRightVisited { get; set; }
        public bool IsLeftVisited { get; set; }
        public bool IsTopVisited { get; set; }
        public bool IsBottomVisited { get; set; }

        public Symbol(string characer, Coordinates coordinates)
        {
            Character = characer;
            Coordinates = coordinates;
            IsRightVisited = false;
            IsLeftVisited = false;
            IsTopVisited = false;
            IsBottomVisited = false;
        }
        public Symbol(Coordinates coordinates)
        {
            Coordinates = coordinates;
            IsRightVisited = false;
            IsLeftVisited = false;
            IsTopVisited = false;
            IsBottomVisited = false;
        }
    }
}
