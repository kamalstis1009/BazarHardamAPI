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
            foreach (var item in models)
            {
                await AddInvStockSummary(item);
            }
            _context.SSL_Inventory.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddInvStockSummary(SSL_Inventory model)
        {
            var item = await _context.SSL_InvStockSummary.FirstOrDefaultAsync(index => index.ProductId == model.ProductId && index.InvStoreId == model.InvStoreId);
            if (item != null)
            {
                item.ReceivedQty += model.Quantity;
                item.BalanceQty += model.Quantity;
                item.OCode = model.OCode;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            } 
            else 
            {
                var obj = new SSL_InvStockSummary
                {
                    InvStoreId = model.InvStoreId,
                    ProductId = model.ProductId,
                    //Barcode = A.Id,
                    ReceivedQty = model.Quantity,
                    //DeliveryQty = A.Id,
                    //StoreTransferQty = A.Id,
                    //SupplierReturnQty = A.Id,
                    //DamageQty = A.Id,
                    //SoldQty = A.Id,
                    //SalesReturnQty = A.Id,
                    BalanceQty = model.Quantity,
                    OCode = model.OCode
                };
                _context.SSL_InvStockSummary.Add(obj);
                return await _context.SaveChangesAsync();
            }
        }

        //======================================================| GET
        public async Task<List<Inventory>> GetAllInventory()
        {
            /*return await (from A in _context.SSL_Inventory
                              join B in _context.SSL_Vendor on A.VendorId equals B.Id
                              join C in _context.SSL_InvStore on A.InvStoreId equals C.Id
                              join D in _context.SSL_Product on A.ProductId equals D.Id
                              select new Inventory
                              {
                                  ChallanDate = A.ChallanDate,
                                  ChallanRef = A.ChallanRef,
                                  InvStore = C,
                                  Vendor = B,
                                  Remarks = A.Remarks,
                                  Product = D,
                                  Quantity = A.Quantity,
                                  CostUnitPrice = A.CostUnitPrice,
                                  TotalAmount = A.TotalAmount
                              }).ToListAsync();*/
            return null;
        }

        public async Task<List<Inventory>> GetAllInventoryGroupBy()
        {
            /*var list = await _context.SSL_Inventory.ToListAsync().ConfigureAwait(false); //.Where(index => index.OCode == oCode)
            return list.GroupBy(index => new { index.InvStoreId, index.ProductId }).Select(item => new Inventory {
                ChallanDate = item.First().ChallanDate,
                ChallanRef = item.First().ChallanRef,
                InvStoreId = item.First().InvStoreId,
                VendorId = item.First().VendorId,
                Remarks = item.First().Remarks,
                ProductId = item.First().ProductId,
                ProductName = _context.SSL_Product.FirstOrDefault(q => q.Id == item.Key.ProductId).Name,
                Quantity = item.Sum(q => q.Quantity), 
                CostUnitPrice = item.Sum(q => q.CostUnitPrice), 
                TotalAmount = item.Sum(q => q.TotalAmount) 
            }).ToList();*/
            return await _context.Database.SqlQuery<Inventory>("ChallanSummary_Lists").ToListAsync();
        }

        public async Task<List<SSL_InvStore>> GetAllInvStores()
        {
            return await _context.SSL_InvStore.ToListAsync();
        }

        //======================================================| ProductUnit
        public async Task<List<SSL_ProductUnit>> GetAllProductUnits()
        {
            return await _context.SSL_ProductUnit.ToListAsync();
        }
    }
}