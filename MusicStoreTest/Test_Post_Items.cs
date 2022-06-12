using System;
using Xunit;
using MusicStore.Models;
using MusicStore.Services;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace MusicStoreTest
{
    public class Test_Post_Items
    {
        public MockDataStore MockData = new();
        public List<Item> Echantillon => GetEchantillon();
        public List<Item> GetEchantillon()
        {
            return MockData.Items;
        }

        [Fact]
        public async Task Post_Item_Success()
        {
            int qtty = Echantillon.Count;
            Item itemEnDur = new Item { Id = "6", Nom = "Les temps révolus", Artiste = "Francis Lechien", Annee = 2002 };
            await MockData.AddItemAsync(itemEnDur); 
            var get = await MockData.GetItemsAsync();
            Assert.Equal(qtty+1, get.Count());                    
            Assert.NotEmpty(get);
        }

        [Fact]
        public async Task Post_Item_Failure()
        {
            int qtty = Echantillon.Count;
            Item itemEnDur = new Item { Id = "7", Nom = "La banane", Artiste = "Franky Bernard", Annee = 2012 };
            await MockData.AddItemAsync(itemEnDur);
            var get = await MockData.GetItemsAsync();
            Assert.True(get.Count() == 6);
        }

        [Fact]
        public async Task Post_Item_CheckData_Success()
        {
 
            Item itemEnDur = new Item { Id = "6", Nom = "LA Woman", Artiste = "The Doors", Annee = 1971 };
            await MockData.AddItemAsync(itemEnDur);
            var get = await MockData.GetItemsAsync();
            Item itemToValidate = get.First(i => i.Id == "6");
            Assert.NotNull(itemToValidate);
            Assert.Equal(itemEnDur, itemToValidate);
            
        }

        [Fact]
        public async Task Post_Item_CheckData_Failure()
        {

            Item itemEnDur = new Item {  };
            await MockData.AddItemAsync(itemEnDur);
            var get = await MockData.GetItemsAsync();
            
            Assert.True(get.Count() == 6);

        }
        
    }
}