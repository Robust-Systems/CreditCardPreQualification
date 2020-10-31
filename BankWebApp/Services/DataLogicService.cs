using DataLogic;
using DataLogic.Models;
using System;
using System.Collections.Generic;

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

    public CreditCard AddApplicant(string firstName, string lastName, DateTime dateOfBirth, int? annualIncome, out string errorMesage)
    {
      errorMesage = null;
      var creditCard = _applicantProcessor.AddApplicant(firstName, lastName, dateOfBirth, annualIncome, out errorMesage);

      return creditCard;
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
