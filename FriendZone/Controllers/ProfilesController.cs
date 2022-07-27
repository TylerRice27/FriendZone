using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly FollowsService _fs;

        public ProfilesController(AccountService accountService, FollowsService fs)
        {
            _accountService = accountService;
            _fs = fs;
        }

        [HttpGet]

        public async Task<ActionResult<Profile>> GetProfiles()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                List<Profile> profiles = _accountService.GetProfiles();
                return Ok(profiles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/followers")]
        public ActionResult<Profile> GetFollowers(string id)
        {
            try
            {
                List<FollowerViewModel> followers = _fs.GetFollowers(id);
                return Ok(followers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/following")]
        public ActionResult<Profile> GetFollowing(string id)
        {
            try
            {
                List<FollowerViewModel> followers = _fs.GetFollowing(id);
                return Ok(followers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}