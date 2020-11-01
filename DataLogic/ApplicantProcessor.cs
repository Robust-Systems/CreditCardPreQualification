using DataLogic.Helper;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLogic
{
  public class ApplicantProcessor
  {
    readonly SqlHelper _sqlHelper;
    readonly string _connectionString;

    public ApplicantProcessor(string connectionString)
    {
      _connectionString = connectionString;
      _sqlHelper = new SqlHelper(connectionString);
    }

    public Applicant GetApplicant(int applicationLogID)
    {
      Applicant applicant = null;

      var sqlParameters = new SqlParameter[] { _sqlHelper.CreateParameter("@ApplicationLogID", applicationLogID, DbType.Int32) };

      using (var reader = _sqlHelper.GetDataReader("ApplicationLog_Get", CommandType.StoredProcedure, sqlParameters, out SqlConnection connection))
      {
        if (reader.Read())
        {
          applicant = new Applicant();

          applicant.ApplicationLogID = (int)reader[nameof(applicant.ApplicationLogID)];
          applicant.FirstName = (string)reader[nameof(applicant.FirstName)];
          applicant.LastName = (string)reader[nameof(applicant.LastName)];
          applicant.DateOfBirth = (DateTime)reader[nameof(applicant.DateOfBirth)];
          applicant.AnnualIncome = reader[nameof(applicant.AnnualIncome)] as int? ?? null;
          applicant.CreditCardID = reader[nameof(applicant.CreditCardID)] as int? ?? null;
          applicant.DateApplied = (DateTime)reader[nameof(applicant.DateApplied)];

          CreditCard creditCard = null;

          if (!(applicant.CreditCardID is null))
          {
            creditCard = (new CardProcessor(_connectionString).GetCreditCard(applicant.CreditCardID.Value));
          }

          applicant.EligibleCreditCard = creditCard;
        }

        connection.Close();
        reader.Close();
      }

      return applicant;
    }

    public IEnumerable<Applicant> GetApplicants()
    {
      List<Applicant> applicantList = new List<Applicant>();

      using (var reader = _sqlHelper.GetDataReader("ApplicationLog_GetList", CommandType.StoredProcedure, null, out SqlConnection connection))
      {
        while (reader.Read())
        {
          Applicant applicant = new Applicant();

          applicant.ApplicationLogID = (int)reader[nameof(applicant.ApplicationLogID)];
          applicant.FirstName = (string)reader[nameof(applicant.FirstName)];
          applicant.LastName = (string)reader[nameof(applicant.LastName)];
          applicant.DateOfBirth = (DateTime)reader[nameof(applicant.DateOfBirth)];
          applicant.AnnualIncome = reader[nameof(applicant.AnnualIncome)] as int? ?? null;
          applicant.CreditCardID = reader[nameof(applicant.CreditCardID)] as int? ?? null;
          applicant.DateApplied = (DateTime)reader[nameof(applicant.DateApplied)];

          CreditCard creditCard = null;

          if (!(applicant.CreditCardID is null))
          {
            creditCard = (new CardProcessor(_connectionString).GetCreditCard(applicant.CreditCardID.Value));
          }

          applicant.EligibleCreditCard = creditCard;

          applicantList.Add(applicant);
        }

        connection.Close();
        reader.Close();
      }

      return applicantList;
    }

    public int AddApplicant(string firstName, string lastName, DateTime dateOfBirth, int? annualIncome)
    {
      var paramList = new List<SqlParameter>();
      paramList.Add(_sqlHelper.CreateParameter("@FirstName", firstName, DbType.String));
      paramList.Add(_sqlHelper.CreateParameter("@LastName", lastName, DbType.String));
      paramList.Add(_sqlHelper.CreateParameter("@DateOfBirth", dateOfBirth.Date, DbType.Date));
      paramList.Add(_sqlHelper.CreateParameter("@AnnualIncome", (object)annualIncome ?? DBNull.Value, DbType.Int32));

      var creditCard = GetEligibleCreditCard(dateOfBirth, annualIncome);
      int? creditCardID = creditCard is null ? null : (int?)creditCard.CreditCardID;

      paramList.Add(_sqlHelper.CreateParameter("@CreditCardID", (object)creditCardID ?? DBNull.Value, DbType.Int32));

      _sqlHelper.Insert("ApplicationLog_Add", CommandType.StoredProcedure, paramList.ToArray(), out int applicationLogID);

      return applicationLogID;
    }

    private CreditCard GetEligibleCreditCard(DateTime dateOfBirth, int? annualIncome)
    {
      int age = CalculateAge(dateOfBirth, DateTime.Now);
      var creditCards = (new CardProcessor(_connectionString).GetCreditCards());

      // check which card applicant qualifies for based on age and income
      var creditCard = creditCards.Where(c => c.AgeRestriction <= age && 
                                              annualIncome.HasValue && 
                                              c.AnnualIncomeRestriction.HasValue && 
                                              c.AnnualIncomeRestriction <= annualIncome).FirstOrDefault();

      // if no card found then see if applicant qualifies for default card
      if(creditCard is null)
      {
        creditCard = creditCards.Where(c => c.AgeRestriction <= age && c.IsDefault).FirstOrDefault();
      }

      return creditCard;
    }

    private int CalculateAge(DateTime birthDate, DateTime now)
    {
      int age = now.Year - birthDate.Year;

      if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
        age--;

      return age;
    }
  }
}
