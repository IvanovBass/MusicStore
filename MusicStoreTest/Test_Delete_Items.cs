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
    public class Test_Delete_Items
    {
        public MockDataStore MockData = new();
        public List<Item> Echantillon => GetEchantillon();
        public List<Item> GetEchantillon()
        {
            return MockData.Items;
        }

        /*   [Fact]
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
           }*/

        [Fact]
        public async Task Delete_Item_At_Id_Success()
        {
            int qtty = Echantillon.Count;
            Random random = new();
            int index = random.Next(0, qtty);
            await MockData.DeleteItemAsync(Echantillon[index: index].Id);
            var get = await MockData.GetItemsAsync();
            Assert.Equal(qtty, get.Count()+1);
        }
        [Fact]
        public async Task Delete_Item_At_Id_Failure()
        {
            int qtty = Echantillon.Count;
            Random random = new();
            int index = random.Next(0, qtty);
            await MockData.DeleteItemAsync(Echantillon[index: index].Id);
            var get = await MockData.GetItemsAsync();
            Assert.True(get.Count() == 6);
        }

        [Fact]
        public async Task Delete_Item_At_Id_CheckData_Success()
        {
            Random random = new();
            int index = random.Next(0, qtty);
            await MockData.DeleteItemAsync(Echantillon[index: index].Id);
            var get = await MockData.GetItemsAsync();
            Assert.Equal(qtty, get.Count() + 1);
        }
        /*       [Fact]*/
        /*public async Task Delete_Item_At_Id_Failure()
        {
            Item item = Echantillon[2];
            var id = Echantillon[4].Id;                                                     // ici je prends expressément 2 index différents 2 et 4
            var get = await MockData.GetItemAsync(id);
            Assert.Equal(get, item);
        }
        //Testons un peu plus loin, toujours en Get, si les données retournées en Get mais pour toute une
        //liste d'Item sont correctes et correspondent à ce qu'on mon modèle retournerait

        [Fact]
        public async Task Get_All_Items_CheckData_Success()
        {
            var get = await MockData.GetItemsAsync();
            Assert.Equal(Echantillon, get);
            Assert.True(get.Count() == 6);
        }

        [Fact]
        public async Task Get_All_Items_CheckData_Failure()
        {
            var get = await MockData.GetItemsAsync();
            Assert.False(Echantillon == get);
            Assert.False(get.Count() == 6);
        }*/
    }
}
