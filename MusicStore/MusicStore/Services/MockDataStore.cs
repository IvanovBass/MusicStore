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

        public MockDataStore()
        {
            items = new List<Item>()
                    {
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "First Album", Artiste="Artiste 1", Annee=2051 },
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "Second Album", Artiste="Artiste 2", Annee=2052},
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "Third Album", Artiste="Artiste 3", Annee=2053},
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "Fourth Album", Artiste="Artiste 4", Annee=2054},
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "Fifth Album", Artiste="Artiste 5", Annee=2055},
                        new Item { Id = Guid.NewGuid().ToString(), Nom = "Sixth Album", Artiste="Artiste 6", Annee=2056}
                    };
        }

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