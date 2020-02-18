using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chilicki.StarWars.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chilicki.StarWars.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly FriendService friendService;

        public FriendsController(
            FriendService friendService)
        {
            this.friendService = friendService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Guid friendId)
        {
            await friendService.AddFriend(id, friendId);
            return NoContent();
        }

        [HttpDelete("{id}/{friendId}")]
        public async Task<IActionResult> Delete(Guid id, Guid friendId)
        {
            await friendService.DeleteFriend(id, friendId);
            return NoContent();
        }
    }
}
