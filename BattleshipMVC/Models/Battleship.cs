using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipMVC.Models
{
    public class Battleship
    {
        public Player player;
        public Computer computer;
        public int turnCounter;
        public string winner;
        public Battleship()
        {
            player = new Player();
            computer = new Computer();
            updateUpperScreens();
            turnCounter = 0;
        }

        public void updateUpperScreens()
        {

            player.board.upScreen.screen = player.board.upScreen.getUpperScreenFromOpponent(computer.board.lowScreen);
            computer.board.upScreen.screen = player.board.upScreen.getUpperScreenFromOpponent(player.board.lowScreen);
        }

        void initializeBoard(int[,] board){
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = 0;
                }
            }
        }


        public void playerTurn(int x, int y)
        {
            player.turn(computer.board, new Coordinate(x, y));
            player.board.upScreen.updateHeatMap(computer.board.lowScreen);
            player.board.upScreen.listofOpponentsSunkShips = computer.board.lowScreen.getListofDeadShips();
            turnCounter++;
        }

        public void computerTurn()
        {
            computer.board.upScreen.updateHeatMap(player.board.lowScreen);
            computer.turn(player.board);
            computer.board.upScreen.listofOpponentsSunkShips = player.board.lowScreen.getListofDeadShips();
            computer.board.upScreen.updateHeatMap(player.board.lowScreen);
        }
    }
}