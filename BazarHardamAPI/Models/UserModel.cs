using BazarHardamAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Models
{
    public class UserModel
    {
        public SSL_Authenticate Auth { get; set; }
        public SSL_User User { get; set; }
    }
}