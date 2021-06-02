using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BazarHardamAPI.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly BazarHardamEntities _context = SQLDatabaseContext.Instance.GetDatabaseInstance();

        //======================================================| GET
        public async Task<SSL_Authenticate> GetAuthById(Guid authId)
        {
            return await _context.SSL_Authenticate.FirstOrDefaultAsync(index => index.Id == authId);
        }

        public async Task<SSL_Authenticate> GetAuthByUserAndPass(string username, string password)
        {
            return await _context.SSL_Authenticate.FirstOrDefaultAsync(index => index.Username == username && index.Password == password);
        }

        //======================================================| ADD
        public async Task<int> AddAuthenticate(SSL_Authenticate model)
        {
            var item = await _context.SSL_Authenticate.FirstOrDefaultAsync(index => index.Username == model.Username);
            if (item == null)
            {
                model.Id = Guid.NewGuid();
                _context.SSL_Authenticate.Add(model);
                return await _context.SaveChangesAsync();
            }
            item.Password = model.Password;
            item.Username = model.Username;
            item.Role = model.Role;
            return await _context.SaveChangesAsync();
        }

        //======================================================| PUT/UPDATE
        public async Task<int> UpdateAuthById(SSL_Authenticate model, Guid authId)
        {
            var item = _context.SSL_Authenticate.FirstOrDefault(index => index.Id == authId);
            if (item != null)
            {
                item.Username = model.Username;
                item.Password = model.Password;
                item.Role = model.Role;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdatePasswordByAuthId(Guid id, string password)
        {
            var item = await _context.SSL_Authenticate.FirstOrDefaultAsync(index => index.Id == id);
            if (item != null)
            {
                item.Password = password;
                return await _context.SaveChangesAsync(); //Updated : //If any change the response 1, do not change response 0
            }
            return 0;
        }

    }
}
