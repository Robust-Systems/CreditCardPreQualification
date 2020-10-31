using DataLogic;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApp.Services
{
  public class DataLogicService : IDataLogicService
  {
    readonly CardProcessor _cardProcessor;
    readonly ApplicantProcessor _applicantProcessor;

    public DataLogicService(string connectionString)
    {
      _cardProcessor = new CardProcessor(connectionString);

      _applicantProcessor = new ApplicantProcessor(connectionString);
    }

    public CreditCard GetCreditCard(int creditCardID)
    {
      return _cardProcessor.GetCreditCard(creditCardID);
    }

    public IEnumerable<CreditCard> GetCreditCards()
    {
      return _cardProcessor.GetCreditCards();
    }

    public CreditCard GetDefaultCreditCard()
    {
      return _cardProcessor.GetDefaultCreditCard();
    }
  }
}
