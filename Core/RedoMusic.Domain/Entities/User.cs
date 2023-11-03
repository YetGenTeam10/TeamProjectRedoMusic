using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusic.Domain.Entities
{
    public class User : EntityBase<Guid>
    {
        public User(string userName, string userEmail, string password)
        {
            UserName = userName;
            UserEmail = userEmail;
            Password = password;
        }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
