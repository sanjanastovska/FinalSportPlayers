using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalSportPlayer.Models;

namespace FinalSportPlayer.Controllers
{
    public class HomeController : Controller
    {
        private PlayerDBEntities1 _db = new PlayerDBEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Players.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Players playerToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Players.Add(playerToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {

            var playerToEdit = (from m in _db.Players where m.Id_player == id select m).First();
            return View(playerToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Players playerToEdit)
        {
            var orginalPlayer = (from m in _db.Players where m.Id_player == playerToEdit.Id_player select m).First();

            if (!ModelState.IsValid)
                return View(orginalPlayer);

            _db.Entry(orginalPlayer).CurrentValues.SetValues(playerToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
