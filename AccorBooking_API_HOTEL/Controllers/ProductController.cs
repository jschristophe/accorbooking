using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorBooking.Business;
using AccorBooking.Entity;
using AccorBooking_Entity.EntityApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AccorBooking.Entity;

namespace AccorBooking_API_HOTEL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet("{pageNumber}/{numberObjectPage}")]
        public ActionResult<string> Get(int pageNumber, int numberObjectPage)
        {

            var message = new Message<List<Product>>();
            message.IsSuccess = true;
            message.Date = DateTime.Now;

            message.ServerInfo = ServerInfoManager.GetServerInfo();
            message.ServerInfo.ServiceName = "CATALOG_API_V2";
            var products = ProductBusiness.GetProducts(pageNumber, numberObjectPage).ToList();

            message.Data = products; // JsonConvert.SerializeObject();
            
            var result = JsonConvert.SerializeObject(message);
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
