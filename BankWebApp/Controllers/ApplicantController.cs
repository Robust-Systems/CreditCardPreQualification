using BankWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankWebApp.Controllers
{
  public class ApplicantController : Controller
  {

    public ApplicantController()
    {

    }

    // GET: Applicant/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Applicant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicantModel applicantModel)
    {
      if (ModelState.IsValid)
      {
        // _service.ProcessApplicant(firstName... DoB);
        //return RedirectToAction(nameof(Index));

        //return View("Details", applicantModel);

        var cardModel = new CardModel
        {
          CardName = "Barclaycard",
          APR = 19.5M,
          PromotionalMessage = "Welcome to Barclaycard!"
        };

        return View("EligibleCard", cardModel);
      }

      return View(applicantModel);
    }

    // GET: Applicant/Create
    public IActionResult Details(ApplicantModel applicantModel)
    {
      return View();
    }
  }
}
