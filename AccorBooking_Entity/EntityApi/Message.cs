using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AccorBooking_Entity.EntityApi
{
    [DataContract]
    public class Message<T>
    {
        public Message()
        {
            IsSuccess = true;
            Date = DateTime.Now;
        }

        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }


        [DataMember(Name = "Version")]
        public string Version { get; set; }

        [DataMember(Name = "ServerName")]
        public string ServerName { get; set; }

        [DataMember(Name = "ServerIP")]
        public string ServerIP { get; set; }

        [DataMember(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
