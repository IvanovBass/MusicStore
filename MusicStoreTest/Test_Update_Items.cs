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
            Item item = Echantillon[index];
            Item itemUpdated = new Item { Id = item.Id, Nom="Les temps révolus", Artiste="Francis Lechien", Annee=2002 };
            await MockData.UpdateItemAsync(itemUpdated);
            var get = await MockData.GetItemAsync(item.Id);
            Assert.Equal(get, item);
            Assert.NotNull(get);

        }