using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SF.DAL
{
    public class DbContextFactory
    {
        public static SFContext GetCurrentContext()
        {
            SFContext baseDbContext = CallContext.GetData("SFContext") as SFContext;
            if (baseDbContext == null)
            {
                baseDbContext = new SFContext();
                CallContext.SetData("SFContext", baseDbContext);
            }
            return baseDbContext;
        }
    }
}
