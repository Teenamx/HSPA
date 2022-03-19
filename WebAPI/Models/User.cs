using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User :BaseEntity
    {
       
        public string UserName { get; set; }
        public byte[] Password { get; set; }

        public byte[] PasswordKey { get; set; }



    }
}
