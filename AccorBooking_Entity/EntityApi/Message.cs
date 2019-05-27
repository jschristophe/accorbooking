using AccorBooking.Entity;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;

namespace AccorBooking_Entity.EntityApi
{
    [DataContract]
    public class Message<T>
    {
        public Message()
        {
            

            
        }

        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }

        [DataMember(Name = "Version")]
        public string Version { get; set; }

        //[DataMember(Name = "HostName")]
        //public string HostName { get; set; }

        //[DataMember(Name = "ListHostNameIP")]
        //public List<string> ListHostNameIP { get; set; }

        [DataMember(Name = "ServerInfo")]
        public ServerInformation ServerInfo { get; set; }

        [DataMember(Name = "Date")]
        public DateTime Date { get; set; }



    }
}
