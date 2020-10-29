using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CreditCardsController : ControllerBase
  {
    // GET: api/<CreditCardController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<CreditCardController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<CreditCardController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }
  }
}
