using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Security.DomainModel.Model.Configuration;

namespace Security.DomainModel.Model
{
    public class SecurityContext:DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext>options):base(options)
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<ProjectAction> ProjectActions { get; set; }
        public DbSet<ProjectController> ProjectControllers { get; set; }
        public DbSet<ProjectArea> ProjectAreas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.RoleActionConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ProjectActionConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ProjectControllerConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ProjectAreaConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
