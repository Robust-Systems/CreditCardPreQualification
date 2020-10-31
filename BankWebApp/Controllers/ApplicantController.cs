using BankWebApp.Models;
using BankWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
  public class ApplicantController : Controller
  {
    readonly IDataLogicService _dataLogicService;

    public ApplicantController(IDataLogicService dataLogicService)
    {
      _dataLogicService = dataLogicService;
    }

    // GET: Applicant/Create
    public IActionResult Create()
    {
      var temp0 = _dataLogicService.GetCreditCards();

      var temp1 = _dataLogicService.GetCreditCard(1);

      var temp2 = _dataLogicService.GetDefaultCreditCard();

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
