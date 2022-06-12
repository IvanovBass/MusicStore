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
    public class Test_Get_Items
    {
        public MockDataStore MockData = new();
        public List<Item> Echantillon => GetEchantillon();
        public List<Item> GetEchantillon()
        {
            return MockData.Items;
        }

        [Fact]
        public async Task Get_All_Items_Success()
        {
            int qtty = Echantillon.Count;                 // => correspond à l'arrange, la prépa des données de test
            var get = await MockData.GetItemsAsync();         //=> act = exécution de ma fonction GetItemsAsync()                                 
            Assert.Equal(qtty, get.Count());                        // => Assert = ce que je m'attends avec certitude (Fact) à ce que ça va renvoyer
            Assert.NotEmpty(get);
        }

        [Fact]    // je vais faire la même chose, mais avec le test qui fail  et un not equal
        public async Task Get_All_Items_Failure()
        {
            int qtty = Echantillon.Count;                 // => correspond à l'arrange, la prépa des données de test
            var get = await MockData.GetItemsAsync();         //=> act = exécution de ma fonction GetItemsAsync()                                 
            Assert.NotEqual(qtty, get.Count());                        // => Assert = ce que je m'attends avec certitude (Fact) à ce que ça va renvoyer
            Assert.Empty(get);
        }

        [Fact]    
        public async Task Get_Item_At_Specified_Id_Success()
        {
            Random rand = new();
            int index = rand.Next(0, Echantillon.Count);    
            Item item = Echantillon[index];                
            var get = await MockData.GetItemAsync(item.Id);                                      
            Assert.Equal(get , item);
            Assert.NotNull(get);

        }
        [Fact]
        public async Task Get_Item_At_Specified_Id_Failure()
        {
            Item item = Echantillon[2];
            var id = Echantillon[4].Id;                                                     // ici je prends expressément 
            var get = await MockData.GetItemAsync(id);
            Assert.Equal(get, item);
        }

    }
}