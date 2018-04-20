using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    /// <summary>
    /// Represent SQLite Authros Table record
    /// </summary>
    [Table("Authors")]
    public class Author
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public Author()
        {

        }

        public Author(string name)
        {
            this.Name = name;
        }
    }
}
