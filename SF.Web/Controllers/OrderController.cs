using SF.Core;
using SF.Core.ExceNpoil;
using SF.Model.DataModelDto;
using SF.Model.EnumModel;
using SF.Service;
using SF.Web.Authorization;
using SF.Web.BaseApplication;
using SF.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
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
            //orderList.ForEach(zw =>
            //{
            //    if (!string.IsNullOrEmpty(zw.Status))
            //    {
            //        zw.Status = EnumExtension.GetDescription(typeof(OrderStatusEnum), int.Parse(zw.Status));
            //    }
            //});
            return Json(new { total = gp.TotalCount, rows = orderList }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 立刷
        /// </summary>
        /// <returns></returns>
        public ActionResult VerticalBrush()
        {
            ViewBag.IsAdmin = ServiceHelper.IsAdmin();
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
        /// <summary>
        /// POS
        /// </summary>
        /// <returns></returns>
        public ActionResult FLM()
        {
            ViewBag.channelId = (int)ChannelEnum.FLM;
            return View();
        }
        [HttpPost]
        public JsonResult ExportExcel(string ids, int channel, string orderNo, DateTime? dateFrom, DateTime? dateTo)
        {
            ResultJsonInfo resultJsonInfo = new ResultJsonInfo() { Data = "", ErrorMsg = "", Success = true };
            List<ExportOrderModel> ExportOrderModels = new List<ExportOrderModel>();
            List<OrderDto> list = Service.GetOrderExcel(ids, channel, orderNo, dateFrom, dateTo);
            foreach (var item in list)
            {
                ExportOrderModels.Add(new ExportOrderModel()
                {

                    订单号 = item.OrderNo,
                    姓名 = item.UserName,
                    手机号 = item.Phone,
                    地址 = item.Address,
                    日期 = item.CredateTime.ToString("yyyy-MM-dd"),
                    时间 = item.CredateTime.ToString("HH:mm"),
                    备注 = item.Remark
                });
            }
            if (list == null || list.Count == 0)
            {
                resultJsonInfo.Success = false;
                resultJsonInfo.ErrorMsg = "暂未数据";
            }
            else
            {
                string fileName = "数据导出.xls";
                ExportExcelHelper<ExportOrderModel>.ExportListToExcel_MvcResult(ExportOrderModels, ref fileName);
                var path = "/Export/Temp/" + fileName;
                resultJsonInfo.Data = path;
            }
            return Json(resultJsonInfo);
        }

        [HttpPost]
        public JsonResult DeleteOrder(string ids)
        {
            ResultJsonInfo resultJsonInfo = new ResultJsonInfo() { Data = "", ErrorMsg = "", Success = true };
            try
            {
                if (!Service.Deletes(ids))
                {
                    resultJsonInfo.Success = false;
                }
            }
            catch (Exception ex)
            {
                resultJsonInfo.Success = false;
                resultJsonInfo.ErrorMsg = ex.Message;
            }
            return Json(resultJsonInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, int status)
        {
            ResultJsonInfo resultJsonInfo = new ResultJsonInfo() { Data = "", ErrorMsg = "", Success = true };
            try
            {
                if (!Service.UpdateStatus(id, status))
                {
                    resultJsonInfo.Success = false;
                }
            }
            catch (Exception ex)
            {
                resultJsonInfo.Success = false;
                resultJsonInfo.ErrorMsg = ex.Message;
            }
            return Json(resultJsonInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ImportExcel()
        {
            //1.接收客户端传过来的数据
            HttpPostedFileBase file = Request.Files["file"];//file对应前端选择文件的name属性
            if (file == null || file.ContentLength <= 0)
            {
                return Json("请选择要上传的Excel文件", JsonRequestBehavior.AllowGet);
            }
            Stream streamfile = file.InputStream;
            DataTable dt = new DataTable();
            string FinName = Path.GetExtension(file.FileName);
            if (FinName != ".xls" && FinName != ".xlsx")
            {
                return Json("只能上传Excel文档", JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<ImportModel> list = new List<ImportModel>();
                try
                {
                    if (FinName == ".xls")
                    {
                        list = ImportExcelHelper.GetListFromExcel<ImportModel>(streamfile, "HSSF");
                    }
                    else
                    {
                        list = ImportExcelHelper.GetListFromExcel<ImportModel>(streamfile, "XSSF");
                    }
                    if (Service.ImportExcel(list))
                    {

                        return Json("导入成功", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("导入失败", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json("导入失败 ！" + ex.Message, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}