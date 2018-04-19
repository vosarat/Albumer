using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.ITunes
{
    [DataContract]
    public class ITunesResponce
    {
        [DataMember(Name = "results")]
        public List<ITunesAlbum> Albums { get; set; }
    }
}
