using AccorBooking.Entity;
using AccorBooking_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccorBooking_WEB.Models
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            ListServerInfo = new List<ServerInformation>();

            var serverInfo = ServerInfoManager.GetServerInfo();
            serverInfo.ServiceName = "FRONT_API";
            ListServerInfo.Add(serverInfo);

        }

        public List<ServerInformation> ListServerInfo { get; set; }
    }
}
