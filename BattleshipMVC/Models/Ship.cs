using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Ship
    {
        public int length;
        public string type;
        public Dictionary<Coordinate, bool> isHitDictionary = new Dictionary<Coordinate, bool>(new CoordinateEqualityComparer());

        public Ship(int length, string type)
        {
            this.length = length;
            this.type = type;
        }

        void addCoordinateToDictionary(int x, int y)
        {
            Coordinate temp = new Coordinate(x, y);
            isHitDictionary.Add(temp, false);
        }
    }
}