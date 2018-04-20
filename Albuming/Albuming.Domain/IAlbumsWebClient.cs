using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Domain
{
    /// <summary>
    /// Interface for any web client requesting
    /// for album
    /// </summary>
    public interface IAlbumsWebClient
    {
        /// <summary>
        /// Returns flag identiying whether web request
        /// goes without exeptions and if it does records
        /// result in out param
        /// </summary>
        /// <param name="author"></param>
        /// <param name="albums"></param>
        /// <returns></returns>
        bool GetAlbumsIfConnected(string author, out IEnumerable<IAlbum> albums);
    }
}
