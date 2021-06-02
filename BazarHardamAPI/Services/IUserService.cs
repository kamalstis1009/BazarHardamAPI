using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserByUserPass(string username, string password);
        Task<SSL_User> GetUserById(Guid id);
        Task<decimal> GetBalanceByUserId(Guid userId);
        Task<SSL_OnlineBanking> GetOnlineBankingById(long id);
        Task<List<SSL_OnlineBanking>> GetAllOnlineBankingByUserId(Guid userId);
        Task<List<SSL_PaymentHistory>> GetAllPaymentHistoryByUserId(Guid userId);
        Task<int> AddUser(SSL_User model);
        Task<int> AddOnlineBanking(SSL_OnlineBanking model);
        Task<int> UpdateUserById(Guid id, SSL_User model);
    }
}
