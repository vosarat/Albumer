using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Console
{
    /// <summary>
    /// Helper for presenting albums in console
    /// </summary>
    public static class AlbumsPrinter
    {
        /// <summary>
        /// Writes albums list to Console
        /// </summary>
        /// <param name="albums"></param>
        public static void PrintAlbums(IEnumerable<IAlbum> albums)
        {
            if (albums == null)
                throw new ArgumentNullException("albums");

            if (albums.Any())
            {
                System.Console.WriteLine($"{Environment.NewLine}Нашлись следующие альбомы:{Environment.NewLine}");

                foreach (var album in albums)
                {
                    System.Console.WriteLine(album.Name);
                }

                System.Console.WriteLine();
            }

        }
    }
}