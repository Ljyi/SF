using SF.Model.DataModelDto;
using SF.Service;
using SF.WebAPI.Models;
using System;
using System.Web.Http;

namespace SF.WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        OrderService orderService = null;
        private OrderController()
        {
            this.orderService = new OrderService();
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [Route("api/order/order-add")]
        [HttpPost]
        public ResultModel AddOrder(OrderApiDto orderDto)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel.success = orderService.AddByApi(orderDto);
            }
            catch (Exception ex)
            {
                resultModel.success = false;
                resultModel.message = ex.Message;
            }
            return resultModel;
        }
    }
}
