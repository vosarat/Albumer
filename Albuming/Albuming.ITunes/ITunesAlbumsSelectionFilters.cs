using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Albuming.ITunes
{
    public class ITunesAlbumsSelectionFilters
    {
        public NotSingleFilter NotSingleFilter { get; private set; } = new NotSingleFilter();
        public NotDeluxeFilter NotDeluxeFilter { get; private set; } = new NotDeluxeFilter();
        public FromQueriedArtistFilter FromQueriedArtistFilter { get; private set; } = new FromQueriedArtistFilter();
        public NotRemixFilter NotRemixFilter { get; private set; } = new NotRemixFilter();

        private IEnumerable<ITunesAlbumFilter> filters => new List<ITunesAlbumFilter>()
        {
            NotSingleFilter, NotDeluxeFilter, FromQueriedArtistFilter, NotRemixFilter
        };

        public IEnumerable<ITunesAlbum> SelectSatisfyingAlbums(IEnumerable<ITunesAlbum> albums, string queriedArtist)
        {
            return from a in albums
                   where filters.All(f => f.Off || f.IsPassed(a, queriedArtist))
                   select a;
        }
    }

    public interface ITunesAlbumFilter
    {
        bool Off { get; set; }

        bool IsPassed(ITunesAlbum album, string queriedArtist);
    }

    public class NotSingleFilter : ITunesAlbumFilter
    {
        public bool Off { get; set; }

        public bool IsPassed(ITunesAlbum album, string queriedArtist) => album.TrackCount > 1 && !album.Name.EndsWith(" - Single");
    }

    public class NotDeluxeFilter : ITunesAlbumFilter
    {
        public bool Off { get; set; }

        public bool IsPassed(ITunesAlbum album, string queriedArtist) => !album.Name.ToLower().Contains("deluxe");
    }

    public class NotRemixFilter : ITunesAlbumFilter
    {
        public bool Off { get; set; }

        public bool IsPassed(ITunesAlbum album, string queriedArtist) => !album.Name.ToLower().Contains("remix");
    }

    public class FromQueriedArtistFilter : ITunesAlbumFilter
    {
        public bool Off { get; set; }

        public bool IsPassed(ITunesAlbum album, string queriedArtist)
        {
            bool сyrillic = Regex.IsMatch(queriedArtist, @"\p{IsCyrillic}");
            bool searchedNameFound = album.ArtistName.ToLower() == queriedArtist.ToLower();

            return сyrillic || searchedNameFound;
        }

    }

}
