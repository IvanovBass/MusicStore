using Microsoft.AspNetCore.Mvc;
using MusicStoreAPI.Models;
using MusicStoreAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMusicServices _musicServices;

        public AlbumController(MusicServices albumService) =>
            _musicServices = albumService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _musicServices.GetAsync();


            if (response.Any())
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var friend = await _musicServices.GetAsync(id);

            if (friend is null)
            {
                return NotFound();
            }

            return Ok(friend);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Album newAlbum)
        {
            await _musicServices.CreateAsync(newAlbum);

            return CreatedAtAction(nameof(Get), new { id = newAlbum.Id }, newAlbum);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Album updatedAlbum)
        {
            var album = await _musicServices.GetAsync(id);

            if (album is null)
            {
                return NotFound();
            }

            updatedAlbum.Id = album.Id;

            await _musicServices.UpdateAsync(id, updatedAlbum);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var album = await _musicServices.GetAsync(id);

            if (album is null)
            {
                return NotFound();
            }

            await _musicServices.RemoveAsync(id);

            return NoContent();
        }
    }
}
