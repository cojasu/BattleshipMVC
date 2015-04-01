using BattleshipMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BattleshipMVC.Controllers
{
    public class HomeController : Controller
    {
        
        //
        // GET: /Home/
        Battleship game;
        public ActionResult Index(){
            game = new Battleship();
            Session["gameSession"] = game;
            return View("Index", Session["gameSession"]);
        }

        public ActionResult Target(string target)
        {
            game = Session["gameSession"] as Battleship;
            string[] coord = target.Split(' ');
            int x = Int32.Parse(coord[0]);
            int y = Int32.Parse(coord[1]);
            game.playerTurn(x, y);
            game.computerTurn();
            if (game.player.CheckWin(game.computer.board.lowScreen.Ships))
            {
                game.winner = "Player";
                return PartialView("gameOver", Session["gameSession"] = game);
            }
            else if (game.computer.CheckWin(game.player.board.lowScreen.Ships))
            {
                game.winner = "Computer";
                return PartialView("gameOver", Session["gameSession"] = game);
            }
            else
            {
                Session["gameSession"] = game;
                return PartialView("Battleship", Session["gameSession"]);
            }
        }
    }
}
