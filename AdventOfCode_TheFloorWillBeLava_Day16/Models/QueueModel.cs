using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_TheFloorWillBeLava_Day16.Models
{
    public class QueueModel
    {
        public Symbol Symbol { get; set; }
        public DirectionEnum DirectionLightCameFrom { get;set; }
        public bool IsRightDone { get; set; } = false;
        public bool IsLeftDone { get; set; } = false;
        public bool IsUpDone { get; set; } = false;
        public bool IsDownDone { get; set;} = false;

        public QueueModel(Symbol symbol, DirectionEnum direction)
        {
            Symbol = symbol;
            DirectionLightCameFrom = direction;
        }
    }
}
