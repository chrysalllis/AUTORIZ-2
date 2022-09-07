using _06._09_byMe.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._09_byMe.Logic
{
    internal class AthorizationService
    {
        public static AthorizationResponse
            AthorizationUser(
            string login, string password)
        {

            MyContext context = new MyContext();

            var user = context.Users.
                Where(x => x.Password == password
                && x.Login == login);

            if (user.Count() == 0)
            {
                return new AthorizationResponse
                {
                    Name = "Такого пользователя нет",
                    Accounting = "NoAthorization"
                };
            }

            if (user.Count() > 0)
            {
                return new AthorizationResponse
                {
                    Accounting = user.First().Accounting,
                    Name = user.First().UserName,
                };
            }

            return null;
        }
        public class AthorizationResponse
        {
            public string Name { get; set; }
            public string Accounting { get; set; }

        }
    }
}
