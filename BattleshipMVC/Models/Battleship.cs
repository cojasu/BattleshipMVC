using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Battleship
    {
        Player player;
        Player computer;

        public Battleship()
        {
            player = new Player();
            computer = new Player();
        }
    }
}