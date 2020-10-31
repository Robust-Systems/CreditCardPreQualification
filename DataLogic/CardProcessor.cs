using DataLogic.Helper;
using DataLogic.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
          creditCard.AgeRestriction = reader[nameof(creditCard.AgeRestriction)] as int? ?? null;
          creditCard.AnnualIncomeRestriction = reader[nameof(creditCard.AnnualIncomeRestriction)] as int? ?? null;
          creditCard.PromotionalMessage = (string)reader[nameof(creditCard.PromotionalMessage)];
          creditCard.APR = reader[nameof(creditCard.APR)] as decimal? ?? null;
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
          creditCard.AgeRestriction = reader[nameof(creditCard.AgeRestriction)] as int? ?? null;
          creditCard.AnnualIncomeRestriction = reader[nameof(creditCard.AnnualIncomeRestriction)] as int? ?? null;
          creditCard.PromotionalMessage = (string)reader[nameof(creditCard.PromotionalMessage)];
          creditCard.APR = reader[nameof(creditCard.APR)] as decimal? ?? null;
        }
      }

      return creditCard;
    }
  }
}
