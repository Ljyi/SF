using SF.Core;
using SF.Model.DataModelDto;
using SF.Model.EnumModel;
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
        /// <summary>
        /// 立刷
        /// </summary>
        /// <returns></returns>
        public ActionResult VerticalBrush()
        {
            ViewBag.channelId = (int)ChannelEnum.VerticalBrush;
            return View();
        }
        /// <summary>
        /// 鼎刷
        /// </summary>
        /// <returns></returns>
        public ActionResult TripodBrush()
        {
            ViewBag.channelId = (int)ChannelEnum.TripodBrush;
            return View();
        }
        /// <summary>
        /// 考拉
        /// </summary>
        /// <returns></returns>
        public ActionResult Koala()
        {
            ViewBag.channelId = (int)ChannelEnum.Koala;
            return View();
        }
        /// <summary>
        /// 通联
        /// </summary>
        /// <returns></returns>
        public ActionResult UnitedEffort()
        {
            ViewBag.channelId = (int)ChannelEnum.UnitedEffort;
            return View();
        }
        /// <summary>
        /// 银盛通
        /// </summary>
        /// <returns></returns>
        public ActionResult ShengTong()
        {
            ViewBag.channelId = (int)ChannelEnum.ShengTong;
            return View();
        }
        /// <summary>
        /// POS
        /// </summary>
        /// <returns></returns>
        public ActionResult POS()
        {
            ViewBag.channelId = (int)ChannelEnum.POS;
            return View();
        }
    }
}