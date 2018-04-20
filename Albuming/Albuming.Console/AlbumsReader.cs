using Albuming.Cache;
using Albuming.Domain;
using Albuming.ITunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Console
{
    public static class AlbumsReader
    {
        public static bool HasInternet { get; private set; }
        private static IAlbumsCacheRepository cacheRepository = new SqliteAlbumsCacheRepository();
        private static IAlbumsWebClient webClient = new ITunesAlbumsWebClient();


        public static IEnumerable<IAlbum> GetAlbums(string author)
        {
            if (String.IsNullOrEmpty(author))
                throw new Exception("Не было передано имя автора");

            if (HasInternet = webClient.GetAlbumsIfConnected(author, out IEnumerable<IAlbum> albums))
            {
                cacheRepository.SaveAlbumsOf(author, albums);
            }
            else
            {
                albums = cacheRepository.GetAlbumsOf(author);
            }

            return albums;
        }
    }
}
