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
        private static IAlbumsCacheRepository cacheRepository = null;
        private static IAlbumsWebClient webClient = new ITunesAlbumsWebClient();


        public static IEnumerable<IAlbum> GetAlbums(string author)
        {
            if (String.IsNullOrEmpty(author))
                throw new Exception("Не было передано имя автора");

            IEnumerable<IAlbum> albums;

            if (HasInternet = webClient.GetAlbumsIfConnected(author, out albums))
            {
                //cacheRepository.SaveAlbumsOf(author, albums);
            }
            else
            {
                albums = cacheRepository.GetAlbumsOf(author);
            }

            return albums;
        }
    }
}
