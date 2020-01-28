using _07_Fiap.Web.AspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.Persistences
{
    public class PresidioContext : DbContext
    {
        public DbSet<Cela> Celas { get; set; }
        public DbSet<Presidiario> Presidiarios { get; set; }

        public PresidioContext(DbContextOptions o) : base(o)
        {

        }
    }
}
