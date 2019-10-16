using SF.Core;
using SF.Model.DataModelDto;
using SF.Service;
using SF.Web.BaseApplication;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SF.Web.Controllers
{
    public class OrderController : ServiceController<OrderService>
    {
        // GET: Order
        public ActionResult Index(int channelId)
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="sort"></param>
        /// <param name="sortOrder"></param>
        /// <param name="orderNo"></param>
        /// <param name="channelId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrderGrid(int limit, int offset, string sort, string sortOrder, string orderNo, int channelId, DateTime? dateFrom, DateTime? dateTo)
        {
            TablePageParameter gp = new TablePageParameter() { Limit = limit, Offset = offset, SortName = sort, SortOrder = sortOrder };
            List<OrderDto> orderList = Service.GetOrderGrid(gp, channel: channelId, orderNo: orderNo, dateFrom: dateFrom, dateTo: dateTo);
            return Json(new { total = gp.TotalCount, rows = orderList }, JsonRequestBehavior.AllowGet);
        }
    }
}