using DataLogic.Helper;
using DataLogic.Models;
using System;
using System.Collections.Generic;

namespace DataLogic
{
  public class ApplicantProcessor
  {
    readonly SqlHelper _sqlHelper;

    public ApplicantProcessor(string connectionString)
    {
      _sqlHelper = new SqlHelper(connectionString);
    }

    public IEnumerable<Applicant> GetApplicants()
    {
      return new List<Applicant>();
    }

    public CreditCard AddApplicant(string firstName, string lastName, DateTime dateOfBirth, int? annualIncome, out string errorMesage)
    {
      //Applicant applicant;
      errorMesage = null;
      return null;
    }
  }
}
