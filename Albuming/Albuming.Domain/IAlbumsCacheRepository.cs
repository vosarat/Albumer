using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Domain
{
    /// <summary>
    /// Interface for a storage of albums cache
    /// </summary>
    public interface IAlbumsCacheRepository
    {
        /// <summary>
        /// Gets albums for author stored in cache
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        IEnumerable<IAlbum> GetAlbumsOf(string author);

        /// <summary>
        /// Saves album to cache
        /// </summary>
        /// <param name="author"></param>
        /// <param name="albums"></param>
        void SaveAlbumsOf(string author, IEnumerable<IAlbum> albums);
    }
}
