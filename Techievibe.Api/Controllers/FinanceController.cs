using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techievibe.Api.Finance;

namespace Techievibe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        [HttpGet]
        [Route("transactions")]
        public IActionResult Get()
        {
            TransactionReader rdr = new TransactionReader();

            return Ok(rdr.ReadTransactionsFromFile(@"C:\PHANI_NARRA\PHANI\RESPONSIBILITIES\FINANCES\transactions_2017_to_July2020.csv"));
        }
    }
}