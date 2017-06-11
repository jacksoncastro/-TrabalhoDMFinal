using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDMFinal.Model
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "offset")]
        public int Offset {get; set;}

        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "results")]
        public List<Result> Results { get; set; }

        public Data()
        {
        }

        public Data(int Offset, int Limit, int Total, int Count, List<Result> Results)
        {
            this.Offset = Offset;
            this.Limit = Limit;
            this.Total = Total;
            this.Count = Count;
            this.Results = Results;
        }
    }
}