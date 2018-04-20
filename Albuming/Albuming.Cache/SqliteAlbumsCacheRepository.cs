using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Cache
{
    public class SqliteAlbumsCacheRepository : IAlbumsCacheRepository
    {
        private SqliteCacheDb db = new SqliteCacheDb();

        public IEnumerable<IAlbum> GetAlbumsOf(string author)
        {
            return this.GetAlbumRecordsOf(author);
        }

        public List<Album> GetAllAlbums()
        {
            return db.Table<Album>().ToList();
        }

        public List<Author> GetAllAuthors()
        {
            return db.Table<Author>().ToList();
        }

        public void Clear()
        {
            db.DropTable<Author>();
            db.DropTable<Album>();
        }

        private List<Album> GetAlbumRecordsOf(string authorName)
        {
            string queryString = $"SELECT Albums.Id, Albums.Name, Albums.AuthorId FROM Albums INNER JOIN Authors ON Albums.AuthorId = Authors.Id WHERE Authors.Name = '{authorName}'";
            return db.Query<Album>(queryString);
        }

        public void SaveAlbumsOf(string authorName, IEnumerable<IAlbum> albums)
        {
            int authorId;
            List<Album> existingAuthorAlbumRecords = this.GetAlbumRecordsOf(authorName);
            if (existingAuthorAlbumRecords.Any())
            {
                authorId = existingAuthorAlbumRecords.First().AuthorId;

                //This probably need optimization rewrite
                existingAuthorAlbumRecords.ForEach(r => db.Delete(r));
            }
            else
            {
                Author authorRecord = new Author(authorName);

                //По неизвестной причине возвращает единицу, вместо созданного Id
                int valueFromDb = db.Insert(authorRecord);
                //По этому приходится определять так
                authorId = authorRecord.Id;
            }


            foreach (var album in albums)
            {
                db.Insert(new Album(album.Name, authorId));
            }
        }
    }
}
