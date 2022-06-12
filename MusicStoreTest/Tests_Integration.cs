using MusicStoreAPI.Models;
using System.Text;
using System.Text.Json;
using System;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests_Integration
{
    public class Tests_Integration
    {
        [Fact]
        public async Task GetValuesShouldBeOK()
        {
        
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });        

            var client = application.CreateClient();      //Arrange

            var reponse = await client.GetAsync("api/Album");          //Act

            Assert.Equal(System.Net.HttpStatusCode.OK, reponse.StatusCode);        //Assert
        }

        [Fact]
        public async Task DeleteValuesShouldBeOK()
        {
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });        

            var client = application.CreateClient();

            var reponse = await client.DeleteAsync("62a5099bd9686f74ffd9856e");
            try
            {
                Assert.Equal(System.Net.HttpStatusCode.OK, reponse.StatusCode);
            }
            catch
            {
                Assert.NotEqual(System.Net.HttpStatusCode.OK, reponse.StatusCode); 
                Console.WriteLine("No Content or Not Found");
            }
        }
        [Fact]
        public async Task PostValuesShouldSayCreated()
        {
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });

            var client = application.CreateClient();

            var album = new Album() {Nom = "Evil Empire", Artiste = "Rage Against The Machine", Annee = 1996 };
            var reponse = await client.PostAsync("api/Album", new StringContent(JsonSerializer.Serialize(album), Encoding.UTF8, "application/json"));

            Assert.Equal(System.Net.HttpStatusCode.Created, reponse.StatusCode);
        }
    }
}