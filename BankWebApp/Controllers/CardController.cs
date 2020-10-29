using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
  public class CardController : Controller
  {
    // GET: CardController
    public ActionResult Index()
    {
      return View();
    }

    // GET: CardController/Details/5
    public ActionResult Details(int id)
    {
      var model = new CardModel
      {
        CardName = "Barclaycard",
        APR = 19.5M,
        PromotionalMessage = "Welcome to Barclaycard!"
      };

      return View(model);
    }

    // GET: CardController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: CardController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CardController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: CardController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CardController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: CardController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
