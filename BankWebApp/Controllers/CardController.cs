using BankWebApp.Models;
using BankWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
  public class CardController : Controller
  {
    readonly IDataLogicService _dataLogicService;

    public CardController(IDataLogicService dataLogicService)
    {
      _dataLogicService = dataLogicService;
    }

    public ActionResult ApplicantResult(int applicationLogID)
    {
      var applicant = _dataLogicService.GetApplicant(applicationLogID);

      var creditCard = applicant.EligibleCreditCard;
      CardModel cardModel = null;

      if(!(creditCard is null))
      {
        cardModel = new CardModel()
        {
          CardName = creditCard.CardName,
          PromotionalMessage = creditCard.PromotionalMessage,
          APR = creditCard.APR,
          CardImageSrc = creditCard.ImageFileName
        };
      }

      return View(cardModel);
    }
  }
}
