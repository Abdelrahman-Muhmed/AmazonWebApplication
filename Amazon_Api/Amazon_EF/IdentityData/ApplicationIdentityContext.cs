using Amazon_Core.Model.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_EF.IdentityData
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplictionUser>
    {
        
        public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> contextOptions)
            : base(contextOptions)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure the one-to-one relationship between ApplictionUser and Adress
            modelBuilder.Entity<ApplictionUser>()
                .HasOne(u => u.userAdress)
                .WithOne(a => a.ApplictionUser)
                .HasForeignKey<Adress>(a => a.ApplicationUserId);
        }

    }
}
