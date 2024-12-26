using MassTransitData.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitData
{
    public class ApplicationDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        { }
    }
}
