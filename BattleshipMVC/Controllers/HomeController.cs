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

        [HttpPost]
        public ActionResult Target(string target)
        {
            game = Session["gameSession"] as Battleship;
            string[] coord = target.Split(' ');
            int x = Int32.Parse(coord[0]);
            int y = Int32.Parse(coord[1]);
            Console.WriteLine(x);
            Console.WriteLine(y);
            game.playerUpBoard[x, y] = 1;
            Session["gameSession"] = game;
            return View("Index", Session["gameSession"]);
        }
    }
}
