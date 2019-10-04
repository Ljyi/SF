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
        public SFContext(string nameOrConnectionString, string dbtype) : base(dbtype == DBType.Read ? "name=VendMContextRead" : "name=VendMContext")
        {

        }
        public SFContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
