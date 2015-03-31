using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Computer
    {
        public AI ai;
        public Board board;

        public Computer()
        {
            ai = new AI();
            board = new Board();
        }
        public void takeShot(Coordinate target, Board oppb){
            if (oppb.lowScreen.screen[target.x, target.y].content != "#")
            {
                target.content = oppb.lowScreen.screen[target.x, target.y].content;
                oppb.lowScreen.screen[target.x, target.y].content = "H";
                board.upScreen.hitOrMissScreen[target.x, target.y] = "H";
               // Console.WriteLine("HIT");
            }
            else
            {
                oppb.lowScreen.screen[target.x, target.y].content = "M";
                board.upScreen.hitOrMissScreen[target.x, target.y] = "M";
               // Console.WriteLine("MISS");
            }

            //Console.WriteLine("Computer took shot at X: " + target.x + " Y: " + target.y);

            oppb.lowScreen.Ships.ForEach(delegate(Ship ship)
            {
                if (ship.isHitDictionary.ContainsKey(target))
                {
                    ship.isHitDictionary[target] = true;
                }
            });
        }

        public bool isLegal(Coordinate target)
        {
            if (board.upScreen.screen[target.x, target.y].content != "H")
            {
                if (board.upScreen.screen[target.x, target.y].content != "M")
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
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
        //Logic for taking computers turn. returns true if computer has won.
        public void turn(Board oppb)
        {
            //Get coordinate for shot.
            Coordinate target = new Coordinate();
            do{
                target = ai.chooseMove(oppb, board.upScreen.heatmap);
            }while(!(isLegal(target)));
            
            //Take the Shot
            takeShot(target, oppb);
        }
    }
}