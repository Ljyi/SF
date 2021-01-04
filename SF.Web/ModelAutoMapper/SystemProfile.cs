using AutoMapper;
using SF.Core;
using SF.Model;
using SF.Model.DataModelDto;
using SF.Model.EnumModel;

namespace SF.Web.ModelAutoMapper
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(opt => opt.Id, ptd => ptd.MapFrom(src => src.Id))
                .ForMember(opt => opt.RoleName, ptd => ptd.MapFrom(src => src.RoleName))
                .ForMember(opt => opt.Status, ptd => ptd.MapFrom(src => src.Status));
            CreateMap<SysMenu, SysMenuDto>();
            CreateMap<SysMenuDto, SysMenu>();
            CreateMap<Order, OrderDto>().ForMember(opt => opt.Status, ptd => ptd.MapFrom(src => EnumExtension.GetDescription(typeof(OrderStatusEnum), src.Status)));
            CreateMap<OrderDto, Order>();//.ForMember(opt => opt.Status, ptd => ptd.MapFrom(src => src.Status))
        }
    }
}