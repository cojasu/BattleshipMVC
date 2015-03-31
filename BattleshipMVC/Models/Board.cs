using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Board
    {
        public UpperScreen upScreen;
        public LowerScreen lowScreen;

        public Board()
        {
            upScreen = new UpperScreen();
            lowScreen = new LowerScreen();
        }
    }
}