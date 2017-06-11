using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDMFinal.Model
{
    [DataContract]
    public class Result
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public String Name { get; set; }

        [DataMember(Name = "description")]
        public String Description { get; set; }

        [DataMember(Name = "modified")]
        public String Modified { get; set; }

        [DataMember(Name = "thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        public Result()
        {
        }

        public Result(int Id, String Name, String Description, String Modified, Thumbnail Thumbnail)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Modified = Modified;
            this.Thumbnail = Thumbnail;
        }
    }
}
