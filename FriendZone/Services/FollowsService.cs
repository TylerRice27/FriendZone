using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class FollowsService
    {


        private readonly FollowsRepository _repo;

        public FollowsService(FollowsRepository repo)
        {
            _repo = repo;
        }

        internal Follow Create(Follow followData)
        {
            // Follow found = Get(followData.Id);
            // if (found.FollowerId == followData.FollowerId && found.FollowingId == followData.FollowerId)
            // {
            //     throw new Exception("You are already following this user");
            // }
            return _repo.Create(followData);
        }

        internal Follow Get(int id)
        {
            Follow found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal void Delete(int followId, string userId)
        {
            Follow found = Get(followId);
            if (found.FollowerId != userId)
            {
                throw new Exception("You cannot delete this");
            }
            _repo.Delete(followId);
        }

        internal List<FollowerViewModel> GetFollowers(string id)
        {
            return _repo.GetFollowers(id);
        }
    }
}