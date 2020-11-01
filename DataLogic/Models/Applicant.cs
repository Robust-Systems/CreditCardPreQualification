using System;

namespace DataLogic.Models
{
  public class Applicant
  {
    public int ApplicationLogID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int? AnnualIncome { get; set; }

    public int? CreditCardID { get; set; }

    public DateTime DateApplied { get; set; }

    public CreditCard EligibleCreditCard { get; set; }
  }
}