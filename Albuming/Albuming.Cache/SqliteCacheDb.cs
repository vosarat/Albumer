using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    public class SqliteCacheDb : SQLiteConnection
    {
        public SqliteCacheDb() : base("cache.db")
        {
            this.CreateTable<Album>();
            this.CreateTable<Author>();
        }
    }
}
