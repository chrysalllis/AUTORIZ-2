using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._09_byMe.DB
{
    public class User1
    {

        [Key]
        public int AuthorizationUserId { get; set; }
        public string UserName { get; set; }

        public int UserAge { get; set; }
        public string? Gender { get; set; }
        public string Password { get; set; }
        public string Login { get;  set; }
        public string Accounting { get;  set; }
    }
}
