using BankWebApp.Models;
using BankWebApp.Services;
using DataLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
      //var temp0 = _dataLogicService.GetCreditCards();

      //var temp1 = _dataLogicService.GetCreditCard(1);

      //var temp2 = _dataLogicService.GetDefaultCreditCard();

      //var temp3 = _dataLogicService.AddApplicant("James", "Bond", DateTime.Now.AddYears(-1 * DateTime.Now.Second), 250000);
      //var temp6 = _dataLogicService.AddApplicant("Sean", "Connery", DateTime.Now.AddYears(-1 * DateTime.Now.Second), 13000);
      //var temp7 = _dataLogicService.AddApplicant("Daniel", "Craig", DateTime.Now.AddYears(-1 * DateTime.Now.Second), null);

      //var temp4 = _dataLogicService.GetApplicant(2);

      //var temp5 = _dataLogicService.GetApplicants();

      return View();
    }

    // POST: Applicant/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicantModel applicantModel)
    {

      if (ModelState.IsValid)
      {
        var applicantLogID = _dataLogicService.AddApplicant(applicantModel.FirstName, 
                                                            applicantModel.LastName, 
                                                            applicantModel.DateOfBirth, 
                                                            applicantModel.AnnualIncome);

        return RedirectToAction("ApplicantResult", "Card", new { applicationLogID = applicantLogID });
      }

      return View(applicantModel);
    }

    // GET: Applicant/List
    public IActionResult List()
    {
      var applicants = _dataLogicService.GetApplicants();
      List<ApplicantModel> applicantList = new List<ApplicantModel>();

      foreach(var applicant in applicants)
      {
        applicantList.Add(MapApplicant(applicant));
      }

      return View(applicantList.OrderByDescending(a => a.DateApplied));
    }

    private ApplicantModel MapApplicant(Applicant applicant)
    {
      var applicantModel = new ApplicantModel()
      {
        ApplicationLogID = applicant.ApplicationLogID,
        FirstName = applicant.FirstName,
        LastName = applicant.LastName,
        DateOfBirth = applicant.DateOfBirth,
        AnnualIncome = applicant.AnnualIncome,
        DateApplied = applicant.DateApplied
      };

      applicantModel.EligibleCreditCard = applicant.EligibleCreditCard?.ToString() ?? "Not Qualified";

      return applicantModel;
    }
  }
}
