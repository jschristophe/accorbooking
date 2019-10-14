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
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = new List<string>();
            result.Add("(Default) Hostname FRONT API=" + System.Net.Dns.GetHostName());
            //result.Add("IP FORNT API =" + System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0).ToString());

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            //Console.WriteLine(ip.Address.ToString());
                            result.Add("IP FRONT API = " + ip.Address.ToString());
                        }
                    }
                }
            }

            return result;
            //return new string[] { "value1", "value2" };
        }


    }
}
