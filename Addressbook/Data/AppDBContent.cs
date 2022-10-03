using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addressbook.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbook.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}
