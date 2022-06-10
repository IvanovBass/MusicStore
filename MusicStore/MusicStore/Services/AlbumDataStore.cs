using MusicStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    
    public class AlbumDataStore : IDataStore<Item>
    {
        public List<Item> items;

        static HttpClientHandler handler = CreateHandler();
        static HttpClient client = new HttpClient(handler);
        static string url = "http://10.0.2.2:5254/api/Album";
        private static HttpClientHandler CreateHandler()
        {
            HttpClientHandler _handler = new HttpClientHandler();
            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                return true;
            };
            return _handler;
        }

        
        public async Task<bool> AddItemAsync(Item item) { 
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var albums = await client.GetStringAsync(url);
            items = JsonConvert.DeserializeObject<List<Item>>(albums);
            return await Task.FromResult(items);
        }
    }
}
