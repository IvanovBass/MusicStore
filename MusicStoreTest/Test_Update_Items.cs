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
    public class Test_Update_Items
    {
        public MockDataStore MockData = new();
        public List<Item> Echantillon => GetEchantillon();
        public List<Item> GetEchantillon()
        {
            return MockData.Items;
        }

        [Fact]
        public async Task Update_Item_At_Id_CheckData_Success()
        {
            Random rand = new();
            int index = rand.Next(0, Echantillon.Count);
            string indexStr = index.ToString();
            Item itemEnDur = new Item { Id = indexStr, Nom = "Les temps révolus", Artiste = "Francis Lechien", Annee = 2002 };
            
            await MockData.UpdateItemAsync(itemEnDur);
            
            Assert.Equal(itemEnDur, Echantillon[index]);
        }

        [Fact]
        public async Task Update_Item_At_Id_Failure()            // je les garde qd même pour montrer que je me suis creusé la nénette mais pour les tests Update_Item il m'indique l'inverse des résultats escomptés.
        {

            Item itemEnDur = new Item { Id = "9", Nom = "La camisole", Artiste = "FranKy Onsmetbien", Annee = 2018 };

            await MockData.UpdateItemAsync(itemEnDur);

            var get = await MockData.GetItemsAsync();

            var newItem = get.Where(e => e.Id == "9").ToList().FirstOrDefault();

            Assert.NotNull(newItem);
            Assert.Equal(itemEnDur, newItem);
            
        }

    }
}