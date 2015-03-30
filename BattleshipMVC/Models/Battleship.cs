using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Battleship
    {
        public int[,] computerUpBoard;
        public int[,] computerDownBoard;
        public int[,] playerUpBoard;
        public int[,] playerDownBoard;
        
        public Battleship()
        {
            computerUpBoard = new int[10, 10];
            computerDownBoard = new int[10, 10];
            playerUpBoard = new int[10, 10];
            playerDownBoard = new int[10, 10];
            initializeBoard(computerUpBoard);
            initializeBoard(computerDownBoard);
            initializeBoard(playerUpBoard);
            initializeBoard(playerDownBoard);
            playerDownBoard[2, 2] = 1;
        }

        void initializeBoard(int[,] board){
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                }
            }
            board[2, 2] = 1;
        }
    }
}