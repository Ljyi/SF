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
            orderEntity.Status = 0;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="channel"></param>
        /// <param name="orderNo"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public List<OrderDto> GetOrderExcel(string ids, int channel, string orderNo, DateTime? dateFrom, DateTime? dateTo)
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
            return Mapper.Map<List<Order>, List<OrderDto>>(orderList.ToList());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Deletes(string ids)
        {
            int[] ida = ids.StrToIntArray();
            Expression<Func<Order, bool>> ex = t => true;
            ex = ex.And(t => !t.IsDelete);
            ex = ex.And(t => ida.Contains(t.Id));
            var orderList = orderRepository.GetEntities(ex).ToList();
            orderList.ForEach(zw =>
            {
                zw.IsDelete = true;
            });
            return orderRepository.Update(orderList) > 0;
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateStatus(int id, int status)
        {
            Order order = orderRepository.Find(id);
            order.Status = status;
            return orderRepository.Update(order) > 0;
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="importModels"></param>
        /// <returns></returns>
        public bool ImportExcel(List<ImportModel> importModels)
        {
            List<Order> list = new List<Order>();
            foreach (var item in importModels)
            {
                Order order = new Order();
                order.Channel = item.渠道;
                order.OrderNo = item.订单号;
                order.UserName = item.姓名;
                order.Phone = item.手机号;
                order.Address = item.地址;
                order.Remark = item.备注;
                order.Status = 0;
                order.IsDelete = false;
                order.CreateUser = "Excel导入";
                order.CredateTime = DateTime.Now;
                list.Add(order);
            }
            return orderRepository.Insert(list) > 0;
        }
    }
}
