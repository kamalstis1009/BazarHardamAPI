using BazarHardamAPI.Repositories;
using System;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IAuthenticateService
    {
        Task<SSL_Authenticate> GetAuthByUserAndPass(string username, string password);
        Task<SSL_Authenticate> GetAuthById(Guid authId);
        Task<SSL_Authenticate> AddAuthenticate(SSL_Authenticate model);
        Task<int> UpdateAuthById(SSL_Authenticate model, Guid authId);
        Task<int> UpdatePasswordByAuthId(Guid id, string password);
    }
}
