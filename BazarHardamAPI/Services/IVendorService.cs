using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IVendorService
    {
        Task<int> AddVendor(SSL_Vendor model);
        Task<int> AddAllVendors(List<SSL_Vendor> models);
        Task<int> DeleteVendorById(int id);
        Task<List<SSL_Vendor>> GetAllVendors();
        Task<SSL_Vendor> GetVendorById(int id);
        Task<int> UpdateVendorById(int id, SSL_Vendor model);
    }
}
