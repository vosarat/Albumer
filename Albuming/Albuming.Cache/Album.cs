using Albuming.Domain;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    [Table("Albums")]
    public class Album : IAlbum
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public Album()
        {

        }

        public Album(string name, int authorId)
        {
            this.Name = name;
            this.AuthorId = authorId;
        }
    }
}
