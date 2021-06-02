using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<long> AddInventory(SSL_Inventory model)
        {
            _context.SSL_Inventory.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> AddAllInventory(List<SSL_Inventory> models)
        {
            _context.SSL_Inventory.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| GET
        public async Task<List<Inventory>> GetAllInventory()
        {
            return await (from A in _context.SSL_Inventory
                          join B in _context.SSL_Vendor on A.VendorId equals B.Id
                          join C in _context.SSL_Product on A.ProductId equals C.Id
                          select new Inventory
                          {
                              Vendor = B,
                              Product = C,
                              ChallanDate = A.ChallanDate,
                              ChallanRef = A.ChallanRef,
                              Quantity = A.Quantity,
                              CostUnitPrice = A.CostUnitPrice,
                              SaleUnitPrice = A.SaleUnitPrice,
                              TotalAmount = A.TotalAmount
                          }).ToListAsync();
        }

        public async Task<List<SSL_ProductUnit>> GetAllProductUnits()
        {
            return await _context.SSL_ProductUnit.ToListAsync();
        }
    }
}