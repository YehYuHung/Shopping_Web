using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopping_Web.Models;

namespace Shopping_Web.Data
{
    public class Shopping_WebContext : DbContext
    {
        public Shopping_WebContext (DbContextOptions<Shopping_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Shopping_Web.Models.Produce> Produce { get; set; } = default!;
    }
}
