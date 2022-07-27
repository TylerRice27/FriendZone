using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fs;

        public FollowsController(FollowsService fs)
        {
            _fs = fs;
        }



        [HttpPost]
        [Authorize]


        // Create realtionship when you click button to follow someone else
        public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
        {
            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                followData.FollowerId = userInfo.Id;

                Follow fs = _fs.Create(followData);
                return Ok(fs);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [HttpGet("{id}")]
        public ActionResult<Follow> Get(int id)
        {
            try
            {
                Follow follow = _fs.Get(id);
                return Ok(follow);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Follow>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _fs.Delete(id, userInfo.Id);
                return Ok(new { Message = "No longer following this user" });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}