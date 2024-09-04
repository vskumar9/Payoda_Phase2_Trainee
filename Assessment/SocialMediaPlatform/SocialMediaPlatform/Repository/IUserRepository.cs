﻿using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User>? GetAllUsers();
        User? GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
