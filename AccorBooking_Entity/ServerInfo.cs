using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace AccorBooking.Entity
{
   public class ServerInfoManager
    {
        public static ServerInformation GetServerInfo()
        {
            var serverInfo = new ServerInformation();
            serverInfo.ServerName = System.Net.Dns.GetHostName();
            serverInfo.ListServerIP = new List<string>();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            serverInfo.ListServerIP.Add(ip.Address.ToString());
                        }
                    }
                }
            }

            return serverInfo;
        }
    }

    public class ServerInformation
    {
        //public ServerInformation (string service)
        //{

        //}

        public string ServiceName { get; set; }
        public string ServerName { get; set; }
        public List<string> ListServerIP { get; set; }
    }

   
}
