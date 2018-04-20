using Albuming.Cache;
using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Albuming.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    System.Console.Write("Найти альбомы исполнителя: ");
                    string author = System.Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(author)) continue;

                    IEnumerable<IAlbum> albums = AlbumsReader.GetAlbums(author);
                    if (albums.Any())
                    {
                        AlbumsPrinter.PrintAlbums(albums);
                    }
                    else if (AlbumsReader.HasInternet)
                    {
                        System.Console.WriteLine("Не удалось найти ни одного альбома указанного автора");
                    }
                    else
                    {
                        System.Console.WriteLine("Не удалось подключиться к интернету. В кеше нет информации по указанному автору");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"В ходе выполнения программы возникла ошибка:{Environment.NewLine}{ex}");
            }

            System.Console.ReadLine();
        }
    }
}
