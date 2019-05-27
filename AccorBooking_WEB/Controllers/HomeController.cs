using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccorBooking_WEB.Models;
using AccorBooking_WEB.Api;
using System.Configuration;
using Microsoft.Extensions.Options;
using AccorBooking_Entity;
using AccorBooking.Entity;

namespace AccorBooking_WEB.Controllers
{
    public class HomeController : Controller
    {
        private AppSettings AppSettings { get; set; }

        public HomeController(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }

        public IActionResult Index()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.ListServerInfo = new List<ServerInformation>();

            var serverInfo = ServerInfoManager.GetServerInfo();
            serverInfo.ServiceName = "FRONT_API";
            productViewModel.ListServerInfo.Add(serverInfo);

            try
            {
                var apiClient = new ApiClient(new Uri(AppSettings.BaseUrlCatalogApi));
                var products = apiClient.GetProducts().Result.Data;

                var serverInfoApi = apiClient.GetProducts().Result.ServerInfo;
                productViewModel.ListServerInfo.Add(serverInfoApi);
            }
            catch (Exception e)
            {

                
            }
            
            return View(productViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
