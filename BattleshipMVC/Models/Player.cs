using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Player
    {
        public Board board;

        public Player()
        {
            board = new Board();
        }

        public void turn(Board oppBoard, Coordinate target)
        {
            TakeShot(oppBoard, target);
        }

        public void TakeShot(Board oppB, Coordinate target)
        {
            //Update boards
            if (oppB.lowScreen.screen[target.x, target.y].content != "#")
            {
                target.content = oppB.lowScreen.screen[target.x, target.y].content;
                oppB.lowScreen.screen[target.x, target.y].content = "H";
                board.upScreen.hitOrMissScreen[target.x, target.y] = "H";
            }
            else
            {
                oppB.lowScreen.screen[target.x, target.y].content = "M";
                board.upScreen.hitOrMissScreen[target.x, target.y] = "M";
            }

            //Update opponent's ShipData
            oppB.lowScreen.Ships.ForEach(delegate(Ship ship)
            {
                if (ship.isHitDictionary.ContainsKey(target))
                {
                    ship.isHitDictionary[target] = true;
                }
            });
        }

        public bool CheckWin(List<Ship> s)
        {
            bool didWin = true;
            s.ForEach(delegate(Ship ship)
            {
                foreach (KeyValuePair<Coordinate, bool> coord in ship.isHitDictionary)
                {
                    if (coord.Value == false)
                    {
                        didWin = false;
                        break;
                    }
                }
            });

 
            return didWin;
        }

    }
}