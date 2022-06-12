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
            int qtty = Echantillon.Count;                 // => correspond � l'arrange, la pr�pa des donn�es de test
            var get = await MockData.GetItemsAsync();         //=> act = ex�cution de ma fonction GetItemsAsync()                                 
            Assert.Equal(qtty, get.Count());                        // => Assert = ce que je m'attends avec certitude (Fact) � ce que �a va renvoyer
            Assert.NotEmpty(get);
        }

        [Fact]    // je vais faire la m�me chose, mais avec le test qui fail  et un not equal
        public async Task Get_All_Items_Failure()
        {
            int qtty = Echantillon.Count;                 // => correspond � l'arrange, la pr�pa des donn�es de test
            var get = await MockData.GetItemsAsync();         //=> act = ex�cution de ma fonction GetItemsAsync()                                 
            Assert.NotEqual(qtty, get.Count());                        // => Assert = ce que je m'attends avec certitude (Fact) � ce que �a va renvoyer
            Assert.Empty(get);
        }

        [Fact]    
        public async Task Get_Item_At_Id_CheckData_Success()
        {
            Random rand = new();
            int index = rand.Next(0, Echantillon.Count);    
            Item item = Echantillon[index];                
            var get = await MockData.GetItemAsync(item.Id);                                      
            Assert.Equal(get , item);
            Assert.NotNull(get);

        }
        [Fact]
        public async Task Get_Item_At_Id_CheckData_Failure()
        {
            Item item = Echantillon[2];
            var id = Echantillon[4].Id;                                                     // ici je prends express�ment 2 index diff�rents 2 et 4
            var get = await MockData.GetItemAsync(id);
            Assert.Equal(get, item);
        }
        //Testons un peu plus loin, toujours en Get, si les donn�es retourn�es en Get mais pour toute une
        //liste d'Item sont correctes et correspondent � ce qu'on mon mod�le retournerait

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
        }
    }
}