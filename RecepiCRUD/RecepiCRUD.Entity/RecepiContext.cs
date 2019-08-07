using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecepiCRUD.Entity
{
    public class RecepiContext : DbContext
    {
        public RecepiContext()
        {

        }

        public RecepiContext(DbContextOptions<RecepiContext> options) : base(options)
        {

        }

        public DbSet<Recepi> Recepies { get; set; }
    }
}
