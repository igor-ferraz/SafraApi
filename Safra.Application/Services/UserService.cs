using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Safra.Domain.ApplicationServices;
using Safra.Domain.Repositories;

namespace Safra.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> SaveToken(string clientId, string token)
        {
            return await userRepository.SaveToken(clientId, token);
        }

        public async Task<string> GetCurrentTokenByAccount(string id)
        {
            return await userRepository.GetCurrentTokenByAccount(id);
        }
    }
}
