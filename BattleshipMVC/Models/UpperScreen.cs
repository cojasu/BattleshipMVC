using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class UpperScreen
    {
        public Coordinate[,] screen = new Coordinate[10, 10];
        public string[,] hitOrMissScreen = new string[10, 10];
        public Coordinate[,] heatmap = new Coordinate[10, 10];
        public List<Ship> listofOpponentsSunkShips = new List<Ship>();


        public UpperScreen()
        {
            for (int j = 0; j < screen.GetLength(1); j++)
            {
                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    screen[i, j] = new Coordinate(i, j);
                    hitOrMissScreen[i, j] = "#";
                    heatmap[i, j] = new Coordinate(i, j);
                }
            }


        }

        public Coordinate[,] getUpperScreenFromOpponent(LowerScreen screen)
        {
            UpperScreen tempScreen = new UpperScreen();
            for (int j = 0; j < tempScreen.screen.GetLength(1); j++)
            {
                for (int i = 0; i < tempScreen.screen.GetLength(0); i++)
                {
                    tempScreen.screen[i, j] = screen.screen[i, j];
                }
            }
            return tempScreen.screen;
        }

        #region Heatmap Stuff
        public void updateHeatMap(LowerScreen ls)
        {
            getCounts(ls);
        }

        void getCounts(LowerScreen ls)
        {
            List<Coordinate> listOfCoordinatesFromSunkShips = new List<Coordinate>();
            listofOpponentsSunkShips.ForEach(delegate(Ship ship)
            {
                foreach (KeyValuePair<Coordinate, bool> coord in ship.isHitDictionary)
                {
                    listOfCoordinatesFromSunkShips.Add(coord.Key);
                }
            });

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    heatmap[i, j].count = 0;
                }
            }
            foreach (Ship ship in ls.Ships)
            {
                if (shipIsAlive(ship))
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            countShipFitHorizontal(ship, i, j, listOfCoordinatesFromSunkShips);
                            countShipFitVertical(ship, i, j, listOfCoordinatesFromSunkShips);
                        }
                    }
                }
            }
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (hitOrMissScreen[i, j] == "H")
                    {
                        heatmap[i, j].count = 0;
                    }
                    if (hitOrMissScreen[i, j] == "M")
                    {
                        heatmap[i, j].count = 0;
                    }
                }
            }
        }


        bool shipIsAlive(Ship ship)
        {
            foreach (KeyValuePair<Coordinate, bool> coord in ship.isHitDictionary)
            {
                if (coord.Value == false)
                {
                    return true;
                }
            }
            return false;
        }

        void countShipFitVertical(Ship ship, int x, int y, List<Coordinate> list)
        {
            for (int i = 0; i < ship.length; i++)
            {
                if (y + i > 9)
                {
                    return;
                }
            }
            for (int i = 0; i < ship.length; i++)
            {
                foreach (Coordinate coord in list)
                {
                    Coordinate tempCoord = new Coordinate(x, y + i);
                    if (tempCoord.x == coord.x && tempCoord.y == coord.y)
                    {
                        return;
                    }
                }
            }
            for (int i = 0; i < ship.length; i++)
            {
                if (hitOrMissScreen[x, y + i] == "M")
                {
                    return;
                }
            }
            for (int i = 0; i < ship.length; i++)
            {

                if (hitOrMissScreen[x, y + i] == "H")
                {
                    if (y + i - 1 > -1)
                    {
                        if (y + i + 1 < 10)
                        {
                            if (hitOrMissScreen[x, y + i + 1] == "H")
                            {
                                heatmap[x, y + i - 1].count += 6;
                            }
                            else
                            {
                                heatmap[x, y + i - 1].count += 3;
                            }
                        }
                        else
                        {
                            heatmap[x, y + i - 1].count += 3;
                        }
                    }
                    if (y + i + 1 < 10)
                    {
                        if (y + i - 1 > -1)
                        {
                            if (hitOrMissScreen[x, y + i - 1] == "H")
                            {
                                heatmap[x, y + i + 1].count += 6;
                            }
                            else
                            {
                                heatmap[x, y + i + 1].count += 3;
                            }
                        }
                        else
                        {
                            heatmap[x, y + i + 1].count += 3;
                        }
                    }
                }
            }

            for (int i = 0; i < ship.length; i++)
            {
                heatmap[x, y + i].count++;
            }
        }

        void countShipFitHorizontal(Ship ship, int x, int y, List<Coordinate> list)
        {
            for (int h = 0; h < ship.length; h++)
            {
                if (x + h > 9)
                {
                    return;
                }
            }
            for (int i = 0; i < ship.length; i++)
            {
                foreach (Coordinate coord in list)
                {
                    Coordinate tempCoord = new Coordinate(x + i, y);
                    if (tempCoord.x == coord.x && tempCoord.y == coord.y)
                    {
                        return;
                    }
                }
            }
            for (int j = 0; j < ship.length; j++)
            {
                if (hitOrMissScreen[x + j, y] == "M")
                {
                    return;
                }
            }
            for (int i = 0; i < ship.length; i++)
            {
                {
                    if (hitOrMissScreen[x + i, y] == "H")
                    {
                        if (x + i - 1 > -1)
                        {
                            if (x + i + 1 < 10)
                            {
                                if (hitOrMissScreen[x + i + 1, y] == "H")
                                {
                                    heatmap[x + i - 1, y].count += 6;
                                }
                                else
                                {
                                    heatmap[x + i - 1, y].count += 3;
                                }
                            }
                            else
                            {
                                heatmap[x + i - 1, y].count += 3;
                            }
                        }
                        if (x + i + 1 < 10)
                        {
                            if (x + i - 1 > -1)
                            {
                                if (hitOrMissScreen[x + i - 1, y] == "H")
                                {
                                    heatmap[x + i + 1, y].count += 6;
                                }
                                else
                                {
                                    heatmap[x + i + 1, y].count += 3;
                                }
                            }
                            else
                            {
                                heatmap[x + i + 1, y].count += 3;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < ship.length; i++)
            {
                heatmap[x + i, y].count++;
            }
        }

        #endregion




    }
}