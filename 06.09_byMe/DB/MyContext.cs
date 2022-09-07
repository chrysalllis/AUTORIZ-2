using _06._09_byMe.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._09_byMe.DB
{
    public class MyContext : DbContext
    {
        private string conectString =
     "server=192.168.10.160;database=k.grkv.IS_20_03; user id=stud; password = stud";

        protected override
            void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conectString);

        }


        public DbSet<User1>
             Users
        { get; set; }

    }
}
