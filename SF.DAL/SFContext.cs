using SF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.DAL
{
    public class SFContext : DbContext
    {
        public SFContext() : base("name=SFContext")
        {
            //延迟加载
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<SFContext>(null);
        }
        /// <summary>
        /// 读写分离
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="dbtype"></param>
        public SFContext(string nameOrConnectionString, string dbtype) : base(dbtype == DBType.Read ? "name=SFContextRead" : "name=SFContext")
        {

        }
        public SFContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<User> User { get; set; }
        public DbSet<SysMenu> SysMenu { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserRights> UserRights { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ExcelTable> ExcelTable { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<SysMenu>();
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<UserRole>();
            modelBuilder.Entity<UserRights>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<ExcelTable>();
        }
    }
}
