using BazarHardamAPI.Models;
using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BazarHardamAPI.Services
{
    public class UserService : IUserService
    {

        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();


        //======================================================| GET
        public async Task<UserModel> GetUserByUserPass(string username, string password)
        {
            var item = await _context.SSL_Authenticate.FirstOrDefaultAsync(index => index.Username == username && index.Password == password);
            if (item != null)
            {
                var model = await _context.SSL_User.FirstOrDefaultAsync(index => index.Id == item.Id);
                return new UserModel
                {
                    Auth = item,
                    User = model ?? null
                };
            }
            return null;
        }

        public async Task<SSL_User> GetUserById(Guid id)
        {
            return await _context.SSL_User.FirstOrDefaultAsync(index => index.Id == id);
        }

        public async Task<decimal> GetBalanceByUserId(Guid userId)
        {
            var param = new SqlParameter("@userId", userId);
            var response = await _context.Database.SqlQuery<decimal>("SELECT SUM(Balance) FROM dbo.SSL_UserBalance WHERE UserId = userId ", param).FirstOrDefaultAsync();
            if (response > 0)
            {
                return response;
            }
            return 0;
        }

        public async Task<SSL_OnlineBanking> GetOnlineBankingById(long id)
        {
            return await _context.SSL_OnlineBanking.FirstOrDefaultAsync(index => index.Id == id);
        }

        public async Task<List<SSL_OnlineBanking>> GetAllOnlineBankingByUserId(Guid userId)
        {
            return await _context.SSL_OnlineBanking.Where(index => index.CreateUser == userId).ToListAsync();
        }

        public async Task<List<SSL_PaymentHistory>> GetAllPaymentHistoryByUserId(Guid userId)
        {
            return await _context.SSL_PaymentHistory.Where(index => index.UserId == userId).ToListAsync();
        }

        //======================================================| ADD
        public async Task<int> AddUser(SSL_User model)
        {
            _context.SSL_User.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddOnlineBanking(SSL_OnlineBanking model)
        {
            /*var item = await _context.SSL_OnlineBanking.FirstOrDefaultAsync(index => index.Id == model.Id);
            if (item != null)
            {
                item = model;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }*/
            _context.SSL_OnlineBanking.Add(model);
            return await _context.SaveChangesAsync();
        }

        //======================================================| UPDATE
        public async Task<int> UpdateUserById(Guid id, SSL_User model)
        {
            var item = await _context.SSL_User.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.Id = model.Id;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.PhoneNumber = model.PhoneNumber;
                item.Gender = model.Gender;
                item.BirthDate = model.BirthDate;
                item.Email = model.Email;
                item.Division = model.Division;
                item.District = model.District;
                item.PoliceStation = model.PoliceStation;
                item.Address = model.Address;
                item.Location = model.Location;
                item.ImageName = model.ImageName;
                item.ImagePath = model.ImagePath;
                item.Token = model.Token;
                item.RefId = model.RefId;
                item.CreateUser = model.CreateUser;
                item.CreateDate = model.CreateDate;
                item.EditDate = model.EditDate;
                item.EditUser = model.EditUser;
                item.OCode = model.OCode;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            _context.SSL_User.Add(model);
            return await _context.SaveChangesAsync();
        }











        /*
         private readonly SSL_Ecommerce_Entities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| ADD
        public async Task<int> AddTask(SSL_Vendor model)
        {
            _context.SSL_Vendor.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAllTasks(List<SSL_Vendor> models)
        {
            _context.SSL_Vendor.AddRange(models);
            return await _context.SaveChangesAsync();
        }

        //======================================================| DELETE
        public async Task<int> DeleteTaskById(Guid id, string oCode)
        {
            var item = await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id && index.OCode == oCode);
            if (item != null)
            {
                _context.SSL_Vendor.Remove(item);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        //======================================================| GET
        public async Task<List<SSL_Vendor>> GetAllTaskForAssign(string oCode)
        {
            return await _context.SSL_Vendor.Where(index => index.Status != "Completed" && index.OCode == oCode).ToListAsync();
        }

        public async Task<SSL_Vendor> GetTaskById(Guid id, string oCode)
        {
            return await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id && index.OCode == oCode);
        }

        //======================================================| UPDATE
        public async Task<int> UpdateTaskById(Guid id, SSL_Vendor model)
        {
            var item = await _context.SSL_Vendor.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.VendorName = model.VendorName;
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
         */

    }
}