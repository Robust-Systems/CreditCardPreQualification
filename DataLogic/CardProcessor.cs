using DataLogic.Helper;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLogic
{
  public class CardProcessor
  {
    readonly SqlHelper _sqlHelper;

    public CardProcessor(string connectionString)
    {
      _sqlHelper = new SqlHelper(connectionString);
    }

    public IEnumerable<CreditCard> GetCreditCards()
    {
      List<CreditCard> creditCards = new List<CreditCard>();

      using (var reader = _sqlHelper.GetDataReader("CreditCard_GetList", CommandType.StoredProcedure, null, out SqlConnection connection))
      {
        while (reader.Read())
        {
          CreditCard creditCard = new CreditCard();

          creditCard.CreditCardID = (int)reader[nameof(creditCard.CreditCardID)];
          creditCard.CardName = (string)reader[nameof(creditCard.CardName)];
          creditCard.AgeRestriction = (int?)reader[nameof(creditCard.CreditCardID)];
          creditCard.AnnualIncomeRestriction = (int?)reader[nameof(creditCard.AnnualIncomeRestriction)];
          creditCard.APR = (decimal?)reader[nameof(creditCard.APR)];
          creditCard.IsDefault = (bool)reader[nameof(creditCard.IsDefault)];

          creditCards.Add(creditCard);
        }
      }

      return creditCards;
    }

    public CreditCard GetDefaultCreditCard()
    {
      var creditCard = GetCreditCards().FirstOrDefault(c => c.IsDefault);

      return creditCard;
    }

    public CreditCard GetCreditCard(int creditCardID)
    {
      CreditCard creditCard = null;

      var sqlParameters = new SqlParameter[] { _sqlHelper.CreateParameter("@CreditCardID", creditCardID, DbType.Int32) };

      using (var reader = _sqlHelper.GetDataReader("CreditCard_Get", CommandType.StoredProcedure, sqlParameters, out SqlConnection connection))
      {
        if (reader.Read())
        {
          creditCard = new CreditCard();

          creditCard.CreditCardID = (int)reader[nameof(creditCard.CreditCardID)];
          creditCard.CardName = (string)reader[nameof(creditCard.CardName)];
          creditCard.AgeRestriction = (int?)reader[nameof(creditCard.CreditCardID)];
          creditCard.AnnualIncomeRestriction = (int?)reader[nameof(creditCard.AnnualIncomeRestriction)];
          creditCard.APR = (decimal?)reader[nameof(creditCard.APR)];
          creditCard.IsDefault = (bool)reader[nameof(creditCard.IsDefault)];
        }
      }

      return creditCard;
    }
  }
}
