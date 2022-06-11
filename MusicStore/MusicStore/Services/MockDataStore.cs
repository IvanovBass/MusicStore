using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public List<Item> Items => items;

        /*        public MockDataStore()
                {
                    items = new List<Item>()
                    {
                        new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                        new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                        new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                        new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                        new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                        new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
                    };
                }*/

        public async Task<bool> AddItemAsync(Item item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = Items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}