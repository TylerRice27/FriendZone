using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
    public class AccountService
    {
        private readonly AccountsRepository _repo;
        public AccountService(AccountsRepository repo)
        {
            _repo = repo;
        }

        internal string GetProfileEmailById(string id)
        {
            return _repo.GetById(id).Email;
        }
        internal Account GetProfileByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }
        internal Account GetOrCreateProfile(Account userInfo)
        {
            Account profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }

        internal Account Edit(Account editData, string userEmail)
        {
            Account original = GetProfileByEmail(userEmail);
            original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
            original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
            return _repo.Edit(original);
        }



        internal List<Profile> GetProfiles()
        {

            return _repo.Get();
        }
    }
}