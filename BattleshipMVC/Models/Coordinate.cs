using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Coordinate
    {
        public int x;
        public int y;

        Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        Coordinate()
        {
            x = 0;
            y = 0;
        }
    }
}