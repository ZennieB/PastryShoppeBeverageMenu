using DataLibrary.BusinessLogic;
using PastryShoppeMenu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PastryShoppeMenu.Controllers
{
    public class MenuController : Controller
    {
        List<Beverage> AllBeverages { get; set; }
        Random rnd = new Random();

        private List<Beverage> GetAllBeverages()
        {
            try
            {
                return BeverageProcessor.LoadBeverages()
                    .Select(x => new Beverage(x.DrinkId, x.Name, x.Cost, x.Size, x.Description, x.CreatedBy, x.SpecialDrink))
                    .ToList();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new List<Beverage>();
            }
        }

        public MenuController()
        {
            AllBeverages = new List<Beverage>();
            AllBeverages = GetAllBeverages();
        }

        [HttpGet]
        public ActionResult ViewMenu()
        {
            ViewBag.Message = "Menu";

            var currentDrinks = GetAllBeverages();

            return View(currentDrinks);
        }

        [HttpGet]
        public ActionResult CreateDrink()
        {
            ViewBag.Message = "You get to make a drink!";

            return View(new Beverage());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Beverage value)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDrink", value);
            }
            do
            {
                value.BeverageId = rnd.Next(1, 3564815);
            }
            while (AllBeverages.Exists(x => x.BeverageId == value.BeverageId));
            int recordsCreated = BeverageProcessor.CreateBeverage(value.BeverageId, value.Name, value.Cost, value.Size, value.Description, value.CreatedBy, value.SpecialDrink);

            return RedirectToAction("CreateDrink", "Menu");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var beverageToShow = AllBeverages.FirstOrDefault(x => x.BeverageId == id);

            if (beverageToShow == null)
            {
                return HttpNotFound();
            }

            return View(beverageToShow);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var beverageToDelete = AllBeverages.FirstOrDefault(x => x.BeverageId == id);

            if (beverageToDelete == null)
            {
                return HttpNotFound();
            }

            int recordsDeleted = BeverageProcessor.DeleteBeverage(beverageToDelete.BeverageId);

            return RedirectToAction("ViewMenu", "Menu");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var beverageToEdit = AllBeverages.FirstOrDefault(x => x.BeverageId == id);

            if (beverageToEdit == null)
            {
                return HttpNotFound();
            }

            return View(beverageToEdit);

        }


        [HttpPost]
        public ActionResult SaveChanges(Beverage value)
        {
            var beverageToSave = AllBeverages.FirstOrDefault(x => x.BeverageId == value.BeverageId);

            if (beverageToSave == null)
            {
                return HttpNotFound();
            }

            int recordsUpdated = BeverageProcessor.UpdateBeverage(value.BeverageId, value.Name, value.Cost, value.Size, value.Description, value.CreatedBy, value.SpecialDrink);

            return RedirectToAction("ViewMenu", "Menu");

        }
    }
}
