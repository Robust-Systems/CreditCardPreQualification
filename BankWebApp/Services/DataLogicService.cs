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

    public int AddApplicant(string firstName, string lastName, DateTime dateOfBirth, int? annualIncome)
    {      
      return _applicantProcessor.AddApplicant(firstName, lastName, dateOfBirth, annualIncome);
    }

    public Applicant GetApplicant(int applicationLogID)
    {
      return _applicantProcessor.GetApplicant(applicationLogID);
    }

    public IEnumerable<Applicant> GetApplicants()
    {
      return _applicantProcessor.GetApplicants();
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
