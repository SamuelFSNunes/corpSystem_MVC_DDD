using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjectModelDDD.Infra.Data.Context
{
    public class ProjectModelContext : DbContext
    {
        public ProjectModelContext()
            : base("ProjectModelDDD")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //settings to configure important database settings
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //every attributes whit id ahead, set to primary key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());
            //if not specify seet all strings to varchar(100)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
        public override int SaveChanges()
        {
            // Iterate over all tracked entries in the ChangeTracker, filtering those whose entity type has a "RegisterDate" property.
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                // If the entry's state is 'Added', meaning the object is being inserted into the database for the first time,
                // set the "RegisterDate" property value to the current date and time.
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;
                }

                // If the entry's state is 'Modified', meaning the object is being updated,
                // prevent the "RegisterDate" field from being modified, keeping the original value intact.
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegisterDate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
