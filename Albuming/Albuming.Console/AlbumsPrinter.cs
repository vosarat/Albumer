using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuming.Console
{
    public static class AlbumsPrinter
    {
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