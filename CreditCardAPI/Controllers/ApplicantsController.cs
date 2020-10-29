using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApplicantsController : ControllerBase
  {
    // GET: api/<ApplicantsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Applicant1", "Applicant2" };
    }

    // POST api/<ApplicantsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }
  }
}
