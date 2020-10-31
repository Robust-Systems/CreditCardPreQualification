using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApp.Services
{
  public interface IDataLogicService
  {

    IEnumerable<CreditCard> GetCreditCards();

    CreditCard GetCreditCard(int creditCardID);

    CreditCard GetDefaultCreditCard();

  }
}
