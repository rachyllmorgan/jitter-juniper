using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jitter.Models
{
    //passage to database
    public class JitterContext : DbContext
    {
        // creates tables in database
        // Can also use IDbSet & IQueryable
        public DbSet<JitterUser> JitterUsers { get; set; }
        public DbSet<Jot> Jots { get; set; }
    }
}