using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWHCore.Models.Bills.Payable;

namespace HWHCore.Models
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

    }
}
