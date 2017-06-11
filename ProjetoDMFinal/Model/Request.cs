using ProjetoDMFinal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoDMFinal
{
    [DataContract]
    public class Request
    {
        public Request()
        {
        }

        public Request(int Code, String Status, Data Data)
        {
            this.Code = Code;
            this.Status = Status;
            this.Data = Data;
        }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "status")]
        public String Status { get; set; }

        [DataMember(Name = "data")]
        public Data Data { get; set; }
    }
}