using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class UpperBoard
    {
        int[,] board;
        public UpperBoard()
        {
            board = new int[9, 9];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                }
            }
        }
    }
}