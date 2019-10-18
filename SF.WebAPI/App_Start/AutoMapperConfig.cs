using AutoMapper;
using SF.WebAPI.ModelAutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.WebAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SystemProfile>();
            });
        }
    }
}