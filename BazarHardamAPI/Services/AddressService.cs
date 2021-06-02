using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddAddress(SSL_Address model)
        {
            _context.SSL_Address.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAllAddress(List<SSL_Address> models)
        {
            _context.SSL_Address.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| DELETE
        public async Task<int> DeleteAddressById(int id)
        {
            var item = await _context.SSL_Address.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                _context.SSL_Address.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        //======================================================| GET
        public async Task<SSL_Address> GetAddressById(int id)
        {
            return await _context.SSL_Address.FirstOrDefaultAsync(index => index.Id == id);
        }

        public async Task<List<SSL_Address>> GetAllAddressByUserId(Guid userId)
        {
            return await _context.SSL_Address.Where(index => index.UserId == userId).ToListAsync();
        }

        //======================================================| UPDATE
        public async Task<int> UpdateAddressById(int id, SSL_Address model)
        {
            var item = await _context.SSL_Address.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.CareOf = model.CareOf;
                item.Phone = model.Phone;
                item.Division = model.Division;
                item.District = model.District;
                item.Area = model.Area;
                item.Location = model.Location;
                item.Address = model.Address;
                item.UserId = model.UserId;
                item.EditUser = model.EditUser;
                item.EditDate = model.EditDate;
                item.OCode = model.OCode;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return 0;
        }

    }
}