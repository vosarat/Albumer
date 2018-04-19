using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.ITunes
{
    [DataContract]
    public class ITunesAlbum : IAlbum
    {
        [DataMember(Name = "collectionName")]
        public string Name { get; set; }

        [DataMember(Name = "trackCount")]
        public int TrackCount { get; set; }

        [DataMember(Name = "artistName")]
        public string ArtistName { get; set; }
    }
}
