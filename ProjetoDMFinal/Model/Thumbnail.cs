using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDMFinal.Model
{
    [DataContract]
    public class Thumbnail
    {
        [DataMember(Name = "path")]
        public string Path {get; set;}

        [DataMember(Name = "extension")]
        public string Extension { get; set; }

        public Thumbnail()
        {
        }

        public Thumbnail(String Path, String Extension)
        {
            this.Path = Path;
            this.Extension = Extension;
        }
    }
}
