using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebApp.Models
{
  public class ApplicantModel
  {
    public int ApplicationLogID { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public int? AnnualIncome { get; set; }

    public string EligibleCreditCard { get; set; }

    public DateTime DateApplied { get; set; }
  }
}
