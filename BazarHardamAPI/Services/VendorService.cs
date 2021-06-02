using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class VendorService : IVendorService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddVendor(SSL_Vendor model)
        {
            var item = await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Name == model.Name);
            if (item == null)
            {
                _context.SSL_Vendor.Add(model);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> AddAllVendors(List<SSL_Vendor> models)
        {
            _context.SSL_Vendor.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| DELETE
        public async Task<int> DeleteVendorById(int id)
        {
            var item = await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Vendor.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        //======================================================| GET
        public async Task<List<SSL_Vendor>> GetAllVendors()
        {
            return await _context.SSL_Vendor.Where(index => index.Status == "Approved").ToListAsync();
        }

        public async Task<SSL_Vendor> GetVendorById(int id)
        {
            return await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id);
        }

        //======================================================| UPDATE
        public async Task<int> UpdateVendorById(int id, SSL_Vendor model)
        {
            var item = await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.Name = model.Name;
                item.ContactPerson = model.ContactPerson;
                item.PhoneNumber = model.PhoneNumber;
                item.Email = model.Email;
                item.Division = model.Division;
                item.District = model.District;
                item.PoliceStation = model.PoliceStation;
                item.Address = model.Address;
                item.Location = model.Location;
                item.ImageName = model.ImageName;
                item.ImagePath = model.ImagePath;
                item.PersonImageName = model.PersonImageName;
                item.PersonImagePath = model.PersonImagePath;
                item.Status = model.Status;
                item.Token = model.Token;
                item.EditUser = model.EditUser;
                item.EditDate = model.EditDate;
                item.OCode = model.OCode;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return 0;
        }
    }
}