using Albuming.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Albuming.ITunes
{
    public class ITunesAlbumsWebClient : IAlbumsWebClient
    {
        private WebClient webClient;
        public ITunesAlbumsSelectionFilters Filters;

        private DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ITunesResponce));
        private string albumsSearchQueryTemplate => "https://itunes.apple.com/search?term={0}&entity=album&attribute=artistTerm";

        public ITunesAlbumsWebClient()
        {
            this.Filters = new ITunesAlbumsSelectionFilters();
            this.webClient = new WebClient();
        }

        public bool GetAlbumsIfConnected(string author, out IEnumerable<IAlbum> albums)
        {
            try
            {
                albums = this.GetAlbums(author);
                return true;
            }
            catch
            {
                albums = new List<IAlbum>();
                return false;
            }
        }

        private IEnumerable<IAlbum> GetAlbums(string author)
        {
            if (String.IsNullOrEmpty(author))
                throw new Exception("Не передан автор");

            Uri requestUri = new Uri(String.Format(albumsSearchQueryTemplate, author));
            using (var responceStream = webClient.OpenRead(requestUri))
            {
                ITunesResponce responce = (ITunesResponce)serializer.ReadObject(responceStream);
                return this.Filters.SelectSatisfyingAlbums(responce.Albums, author);
            }
        }
    }
}
