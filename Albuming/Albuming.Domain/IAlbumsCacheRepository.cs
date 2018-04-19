using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Domain
{
    public interface IAlbumsCacheRepository
    {
        IEnumerable<IAlbum> GetAlbumsOf(string author);
        void SaveAlbumsOf(string author, IEnumerable<IAlbum> albums);
    }
}
