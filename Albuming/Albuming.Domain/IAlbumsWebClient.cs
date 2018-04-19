using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Domain
{
    public interface IAlbumsWebClient
    {
        bool GetAlbumsIfConnected(string author, out IEnumerable<IAlbum> albums);
    }
}
