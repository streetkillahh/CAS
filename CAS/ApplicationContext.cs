using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CAS.classes;

namespace CAS
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HistoryPurchase> HistoryPurchases { get; set; }    
        public DbSet<Device> Devices { get; set; }
        public ApplicationContext() : base("DefaultConnection") { }
    }
}
