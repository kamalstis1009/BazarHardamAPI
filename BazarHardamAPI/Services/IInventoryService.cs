using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public interface IInventoryService
    {
        Task<long> AddInventory(SSL_Inventory model);
        Task<int> AddAllInventory(List<SSL_Inventory> models);
        Task<List<Inventory>> GetAllInventory();
        Task<List<Inventory>> GetAllInventoryGroupBy();
        Task<List<SSL_InvStore>> GetAllInvStores();
        Task<List<SSL_ProductUnit>> GetAllProductUnits();
    }
}
