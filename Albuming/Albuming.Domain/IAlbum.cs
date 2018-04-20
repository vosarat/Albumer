using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Domain
{
    /// <summary>
    /// Minimal album representation
    /// </summary>
    public interface IAlbum
    {
        string Name { get; }
    }
}
