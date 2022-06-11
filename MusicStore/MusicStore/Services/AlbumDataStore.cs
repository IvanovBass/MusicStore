using MusicStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    
    public class AlbumDataStore : IDataStore<Item>
    {
        public List<Item> items;
        private Item item;
        static string url = "http://10.0.2.2:5254/api/Album";
        static HttpClientHandler handler = CreateAHandler();
        static HttpClient client = new HttpClient(handler);
        
        private static HttpClientHandler CreateAHandler()
        {
            HttpClientHandler _handler = new HttpClientHandler();
            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                return true;
            };
            return _handler;
        }

        
        public async Task<bool> AddItemAsync(Item item) {
            var stringConverted = JsonConvert.SerializeObject(item);
            var albumContent = new StringContent(stringConverted, Encoding.UTF8, "application/json");
            await client.PostAsync(url, albumContent);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateItemAsync(Item item)
        {
            var urlId = url + "/" + item.Id.ToString();
            var converter = JsonConvert.SerializeObject(item);
            var content = new StringContent(converter, Encoding.UTF8, "application/json");
            await client.PutAsync(urlId, content);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            var strings = url + "/" + id;
            await client.DeleteAsync(strings);
            return await Task.FromResult(true);
        }
        public async Task<Item> GetItemAsync(string id)
        {
            var urlId = url + "/" + id;
            var album = await client.GetStringAsync(urlId);
            item = JsonConvert.DeserializeObject<Item>(album);
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var albums = await client.GetStringAsync(url);
            items = JsonConvert.DeserializeObject<List<Item>>(albums);
            return await Task.FromResult(items);
        }
    }
}
