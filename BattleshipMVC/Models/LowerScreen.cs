using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class LowerScreen
    {
       public Coordinate[,] screen = new Coordinate[10, 10];
        public List<Ship> Ships = new List<Ship>();
        public LowerScreen()
        {
 
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = new Coordinate(i, j);
                }
            }
            Ship boat = new Ship(2, "o");
            Ship carrier = new Ship(5, "c");
            Ship battleship = new Ship(4, "b");
            Ship submarine = new Ship(3, "s");
            Ship destroyer = new Ship(3, "d");


            Ships.Add(carrier);
            Ships.Add(battleship);
            Ships.Add(submarine);
            Ships.Add(destroyer);
            Ships.Add(boat);
            initializeShipData();

        }

        void initializeShipData()
        {
            Random rnd = new Random();
            Ships.ForEach(delegate(Ship ship)
            {
                bool spotFound = false;

                do
                {
                    bool addingFlag = true;
                    Coordinate temp = new Coordinate();
                    if (screen[temp.x, temp.y].content == "#")
                    {
                        //generate direction
                        //horizontal
                        int dir = rnd.Next(2);
                        if (dir == 0)
                        {
                            for (int x = 0; x < ship.length; x++)
                            {
                                if (temp.x < 10 && (temp.y + x) < 10)
                                {
                                    if (!(screen[temp.x, temp.y + x].content == "#"))
                                    {
                                        addingFlag = false;
                                    }
                                }
                                else
                                {
                                    addingFlag = false;
                                }
                            }
                            if (addingFlag)
                            {
                                for (int x = 0; x < ship.length; x++)
                                {
                                    screen[temp.x, temp.y + x].content = ship.type;
                                    Coordinate dictTempCoord = new Coordinate(temp.x, temp.y + x, ship.type);
                                    ship.isHitDictionary.Add(dictTempCoord, false);
                                }
                                spotFound = true;
                            }
                        }
                        //Vertical
                        else
                        {
                            for (int x = 0; x < ship.length; x++)
                            {

                                if ((temp.x + x) < 10 && temp.y < 10)
                                {
                                    if ((!(screen[temp.x + x, temp.y].content == "#")))
                                    {
                                        addingFlag = false;
                                    }
                                }
                                else
                                {
                                    addingFlag = false;
                                }
                            }
                            if (addingFlag)
                            {
                                for (int x = 0; x < ship.length; x++)
                                {
                                    screen[temp.x + x, temp.y].content = ship.type;
                                    Coordinate dictTempCoord = new Coordinate(temp.x + x, temp.y, ship.type);
                                    ship.isHitDictionary.Add(dictTempCoord, false);
                                }
                                spotFound = true;
                            }
                        }
                    }

                }while(!spotFound);
            });
        }

        public List<Ship> getListofDeadShips()
        {
            List<Ship> tempList = new List<Ship>();
            Ships.ForEach(delegate(Ship ship)
            {
                bool shipCheck = true;
                foreach (KeyValuePair<Coordinate, bool> coord in ship.isHitDictionary)
                {
                    if (coord.Value == false)
                    {
                        shipCheck = false;
                        break;
                    }
                }
                if (shipCheck)
                {
                    tempList.Add(ship);
                }
            });
            return tempList;
        }
    }
}