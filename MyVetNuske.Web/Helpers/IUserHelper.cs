﻿using Microsoft.AspNetCore.Identity;
using MyVetNuske.Web.Data.Entities;
using System.Threading.Tasks;

namespace MyVetNuske.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }

}
