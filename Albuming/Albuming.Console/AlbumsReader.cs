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
    /// <summary>
    /// Static helper for reading album information
    /// </summary>
    public static class AlbumsReader
    {
        public static bool HasInternet { get; private set; }
        private static IAlbumsCacheRepository cacheRepository = new SqliteAlbumsCacheRepository();
        private static IAlbumsWebClient webClient = new ITunesAlbumsWebClient();

        /// <summary>
        /// Returns albums for artist
        /// first tries internet request
        /// if not succeeded searches local cache
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static IEnumerable<IAlbum> GetAlbums(string author)
        {
            if (String.IsNullOrEmpty(author))
                throw new Exception("Не было передано имя автора");

            if (HasInternet = webClient.GetAlbumsIfConnected(author, out IEnumerable<IAlbum> albums))
            {
                //probably need to do it asyncronisly not to stop ui
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
