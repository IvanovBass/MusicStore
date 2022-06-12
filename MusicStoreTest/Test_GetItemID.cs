using System;
using Xunit;
using MusicStore.Models;

namespace MyFirstUnitTests
{
    public class Test_GetItemID
    {
        Item item1 = new Item
        {
            Id = "62a355be300f6560f28bf612",
            Nom = "Mauvais oeil",
            Artiste = "Lunatic",
            Annee = 1996
        };
        Item item2 = new Item { };   

        string strJsonItem = JsonConverter.Serialize(item1);

        [Fact]
        public void PassingTestJsonSerialization()
        {
            Assert.True(!String.IsNullOrWhiteSpace(strJsonItem));
        }

        [Fact]
        public void FailingTestJsonSerialization()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}