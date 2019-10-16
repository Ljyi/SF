using AutoMapper;
using SF.Core;
using SF.DAL.UnitOfWork;
using SF.Model;
using SF.Model.DataModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SF.Service
{
    public class OrderService : BaseService
    {
        private IRepository<Order> orderRepository = null;
        public OrderService()
        {
            orderRepository = new RepositoryBase<Order>();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>添加成功返回true，否则返回false</returns>
        public bool AddByApi(OrderApiDto entity)
        {
            var orderEntity = Mapper.Map<OrderApiDto, Order>(entity);
            orderEntity.OrderNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            orderEntity.CreateUser = "API";
            orderEntity.CredateTime = DateTime.Now;
            return orderRepository.Insert(orderEntity) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tpg">分页参数</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="dateFrom">创建时间</param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public List<OrderDto> GetOrderGrid(TablePageParameter tpg, int channel, string orderNo, DateTime? dateFrom, DateTime? dateTo)
        {
            Expression<Func<Order, bool>> ex = t => true;
            ex = ex.And(t => !t.IsDelete);
            ex = ex.And(t => t.Channel == channel);
            if (!string.IsNullOrEmpty(orderNo))
            {
                ex = ex.And(t => t.OrderNo == orderNo);
            }
            if (dateFrom.HasValue)
            {
                dateFrom = Convert.ToDateTime((Convert.ToDateTime(dateFrom).ToString("yyyy-MM-dd HH:mm")));
                ex = ex.And(t => t.CredateTime >= dateFrom);
            }
            if (dateTo.HasValue)
            {
                dateTo = Convert.ToDateTime((Convert.ToDateTime(dateTo).ToString("yyyy-MM-dd HH:mm"))).AddMinutes(1).AddSeconds(-1);
                ex = ex.And(t => t.CredateTime <= dateTo);
            }
            var orderList = orderRepository.GetEntities(ex);
            if (tpg == null)
            {
                return Mapper.Map<List<Order>, List<OrderDto>>(orderList.ToList());
            }
            else
            {
                return Mapper.Map<List<Order>, List<OrderDto>>(GetTablePagedList(orderList, tpg));
            }
        }
    }
}
