using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    /// <summary>
    /// Represents cached db
    /// </summary>
    public class SqliteCacheDb : SQLiteConnection
    {
        /// <summary>
        /// Creates worker for "cache.db"
        /// and prepares all tables
        /// </summary>
        public SqliteCacheDb() : base("cache.db")
        {
            this.CreateTable<Album>();
            this.CreateTable<Author>();
        }
    }
}
