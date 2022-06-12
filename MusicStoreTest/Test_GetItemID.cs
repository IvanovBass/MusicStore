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
    public class Test_GetItemID
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
        }

        [Fact]    // je vais faire la m�me chose, mais avec le test qui fail  et un not equal
        public async Task Get_All_Items_Failure()
        {
            int qtty = Echantillon.Count;                 // => correspond � l'arrange, la pr�pa des donn�es de test
            var get = await MockData.GetItemsAsync();         //=> act = ex�cution de ma fonction GetItemsAsync()                                 
            Assert.NotEqual(qtty, get.Count());                        // => Assert = ce que je m'attends avec certitude (Fact) � ce que �a va renvoyer
        }
        /*        [Fact]
                public void PassingTestJsonSerialization()
                {
                    Assert.True(!string.IsNullOrWhiteSpace(strJsonItem));
                }

                [Fact]
                public void FailingTestJsonSerialization()
                {
                    Assert.Equal(5, Add(2, 2));
                }

                int Add(int x, int y)
                {
                    return x + y;
                }*/
    }
}