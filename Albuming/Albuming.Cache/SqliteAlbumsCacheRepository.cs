using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    /// <summary>
    /// SQLite repository that store albums cache
    /// </summary>
    public class SqliteAlbumsCacheRepository : IAlbumsCacheRepository
    {
        private SqliteCacheDb db = new SqliteCacheDb();

        /// <summary>
        /// Returns list of album found for that author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public IEnumerable<IAlbum> GetAlbumsOf(string author)
        {
            return this.GetAlbumRecordsOf(author);
        }

        /// <summary>
        /// Returns list of records retuned
        /// by query by author name
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        private List<Album> GetAlbumRecordsOf(string authorName)
        {
            string queryString = $"SELECT Albums.Id, Albums.Name, Albums.AuthorId FROM Albums INNER JOIN Authors ON Albums.AuthorId = Authors.Id WHERE Authors.Name = '{authorName.ToLower()}'";
            return db.Query<Album>(queryString);
        }

        /// <summary>
        /// Save albums of author to cache tables
        /// or updates records if they exists
        /// </summary>
        /// <param name="authorName"></param>
        /// <param name="albums"></param>
        public void SaveAlbumsOf(string authorName, IEnumerable<IAlbum> albums)
        {
            if (authorName == null)
                throw new ArgumentNullException(authorName);

            authorName = authorName.ToLower();


            if (!this.TryClearRecordsOf(authorName, out int authorId))
            {
                Author authorRecord = new Author(authorName);

                int valueFromDb = db.Insert(authorRecord);
                authorId = authorRecord.Id;
            }

            foreach (var album in albums)
            {
                db.Insert(new Album(album.Name, authorId));
            }
        }

        /// <summary>
        /// Clears cache of author from db
        /// if they exists and sets authorId out
        /// return flag identifiyng whether a record was found
        /// </summary>
        /// <param name="authorName"></param>
        /// <param name="authorId"></param>
        private bool TryClearRecordsOf(string authorName, out int authorId)
        {
            List<Album> existingAuthorAlbumRecords = this.GetAlbumRecordsOf(authorName);

            if (existingAuthorAlbumRecords.Any())
            {
                authorId = existingAuthorAlbumRecords.First().AuthorId;
                existingAuthorAlbumRecords.ForEach(r => db.Delete(r));
                return true;
            }

            authorId = 0;
            return false;
        }
    }
}
