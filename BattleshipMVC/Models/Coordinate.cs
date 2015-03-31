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
        public string content;
        public int count;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
            content = "#";
            count = 0;
        }

        public Coordinate(int x, int y, string con)
        {
            this.x = x;
            this.y = y;
            content = con;
            count = 0;
        }

        public Coordinate()
        {
            this.x = generateRandom();
            this.y = generateRandom();
            content = "#";
            count = 0;
        }

        public Coordinate(List<Coordinate> pastShots)
        {
            bool legal;
            do
            {
                legal = true;
                this.x = generateRandom();
                this.y = generateRandom();
                foreach (Coordinate coord in pastShots)
                {
                    if (coord.x == this.x)
                    {
                        if (coord.y == this.y)
                        {
                            legal = false;
                        }
                    }
                }
            } while (!legal);
            this.content = "#";
        }

        int generateRandom()
        {
            Random rnd = new Random();
            return rnd.Next(10);
        }


    }

    public class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate x, Coordinate y)
        {
            return ((x.x == y.x) & (x.y == y.y) & (x.content == y.content));
        }

        public int GetHashCode(Coordinate obj)
        {
            string combined = obj.x.ToString() + "|" + obj.y.ToString() + "|" + obj.content.ToString();
            return (combined.GetHashCode());
        }
    }
}