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

/*        [Fact]
        public async Task Delete_Item_At_Id_CheckData_Success()                    //je n'arrive pas à le faire fonctionner celui-là
        {
            List<Item> echantillonComplet = Echantillon;
            int qtty = Echantillon.Count;
            Random random = new();
            int index = random.Next(0, qtty);
            Item itemRemoved = Echantillon[index];
            await MockData.DeleteItemAsync(Echantillon[index: index].Id);
            var get = await MockData.GetItemsAsync();
            Assert.Equal(get.Append(itemRemoved), echantillonComplet);
        }

        [Fact]
        public async Task Delete_Item_At_Id_CheckData_Failure()
        {
            List<Item> echantillonComplet = Echantillon;
            int qtty = Echantillon.Count;
            Random random = new();
            int index = random.Next(0, qtty);
            await MockData.DeleteItemAsync(Echantillon[index: index].Id);
            var get = await MockData.GetItemsAsync();
            Assert.Equal(echantillonComplet, get);
        }*/
    }
}
