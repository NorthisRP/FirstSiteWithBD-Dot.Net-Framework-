using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreKeys.Models
{
    public class KeyContext: DbContext
    {
        public DbSet<Key> Keys { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}