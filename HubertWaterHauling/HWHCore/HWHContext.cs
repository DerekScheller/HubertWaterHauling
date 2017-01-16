using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HWHCore.Models;


namespace HWHCore
{
    public class HWHContext : DbContext
    {
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<WaterTruck> Trucks { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<GasReciept> GasReciepts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//
//            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
//            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
//        }
    }
}
