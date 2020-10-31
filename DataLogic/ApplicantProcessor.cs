using DataLogic.Helper;
using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

    public bool AddApplicant(Applicant applicant)
    {


      return true;
    }
  }
}
