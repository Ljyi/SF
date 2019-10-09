using AutoMapper;
using SF.Web.ModelAutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SystemProfile>();
                //cfg.AddProfile<BasicsMapping>();
                //cfg.AddProfile<AdvertMappingProfile>();
                //cfg.AddProfile<ProductMapping>();
                //cfg.AddProfile<OrderMapping>();
                //cfg.AddProfile<StockMapping>();
            });
        }
    }
}