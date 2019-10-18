using AutoMapper;
using SF.Model;
using SF.Model.DataModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.WebAPI.ModelAutoMapper
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<Order, OrderApiDto>();
            CreateMap<OrderApiDto, Order>();
        }
    }
}