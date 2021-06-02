using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IAddressService
    {
        Task<int> AddAddress(SSL_Address model);
        Task<int> DeleteAddressById(int id);
        Task<SSL_Address> GetAddressById(int id);
        Task<List<SSL_Address>> GetAllAddressByUserId(Guid userId);
        Task<int> UpdateAddressById(int id, SSL_Address model);
    }
}
