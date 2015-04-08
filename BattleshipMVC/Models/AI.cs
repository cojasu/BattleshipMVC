using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class AI
    {
        public AI()
        {

        }
        public Coordinate chooseMove(Board oppB, Coordinate[,] heatmap)
        {
            Coordinate holdingCoord = new Coordinate();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (heatmap[i, j].count > holdingCoord.count)
                    {
                        holdingCoord.x = heatmap[i, j].x;
                        holdingCoord.y = heatmap[i, j].y;
                        holdingCoord.count = heatmap[i, j].count;
                    }
                }
            }
            List<Coordinate> tempCoords = new List<Coordinate>();
            tempCoords.Add(holdingCoord);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (heatmap[i, j].count == holdingCoord.count)
                    {
                        if (!(heatmap[i, j].x == holdingCoord.x && heatmap[i, j].y == holdingCoord.y))
                        {
                            tempCoords.Add(heatmap[i, j]);
                        }
                    }
                }
            }
            Random rnd = new Random();
            int r = rnd.Next(tempCoords.Count);
            return tempCoords[r];
        }
    }
}