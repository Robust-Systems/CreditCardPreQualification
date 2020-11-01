using System;
using System.ComponentModel.DataAnnotations;

namespace BankWebApp.Models
{
  public class ApplicantModel
  {
    [Display(Name = "Log ID")]
    public int ApplicationLogID { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Annual Income")]
    public int? AnnualIncome { get; set; }

    [Display(Name = "Eligible Credit Card")]
    public string EligibleCreditCard { get; set; }

    [Display(Name = "Date Applied")]
    public DateTime DateApplied { get; set; }
  }
}
