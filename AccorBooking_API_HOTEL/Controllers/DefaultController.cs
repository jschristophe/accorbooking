using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccorBooking_API_HOTEL.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET 
        [HttpGet]
        public ActionResult<string> Get()
        {
            var result = "API_CATOLOG";           

            return result;
            //return new string[] { "value1", "value2" };
        }

       
    }
}
