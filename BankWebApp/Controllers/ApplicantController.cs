using BankWebApp.Models;
using BankWebApp.Services;
using DataLogic.Models;
using Microsoft.AspNetCore.Mvc;
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
