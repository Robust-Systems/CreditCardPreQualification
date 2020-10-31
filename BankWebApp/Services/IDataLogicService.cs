using DataLogic.Models;
using System;
using System.Collections.Generic;

namespace BankWebApp.Services
{
  public interface IDataLogicService
  {

    IEnumerable<CreditCard> GetCreditCards();

    CreditCard GetCreditCard(int creditCardID);

    CreditCard GetDefaultCreditCard();

    CreditCard AddApplicant(string firstName, string lastName, DateTime dateOfBirth, int? annualIncome, out string errorMesage);

  }
}
