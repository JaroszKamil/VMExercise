
using DataAccess.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace DataAccess.Data
{
    public class VMDBContext:DbContext
    {
        public DbSet<DataCustomer> Customer { get; set; }
        public DbSet<DataAddress> Address { get; set; }

        public VMDBContext(DbContextOptions<VMDBContext> options) : base(options)
        {
                
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is DataCustomer)
            {
                var customer = entity as DataCustomer;

                var old = this.Customer.Where(x => x.CustomerId == customer.CustomerId).First();

                var oldAddress = this.Address.Where(x => x.CustomerId == old.CustomerId
                && x.Name == old.Name).ToList();

                oldAddress.ForEach(x => x.Customer = customer);

                customer.Addresses = oldAddress;

                base.Remove(old);

                this.SaveChanges();

            }

            return base.Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataAddress>()
           .HasKey(c => new { c.CustomerId, c.AddressType });

            modelBuilder.Entity<DataCustomer>()
            .HasKey(c => new { c.CustomerId, c.Name });

            modelBuilder.Entity<DataCustomer>()
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Customer)
                .IsRequired(true)
                .HasForeignKey(x => new { x.CustomerId, x.Name });      

        }

    }
}
