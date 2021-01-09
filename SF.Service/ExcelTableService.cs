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
    public class ExcelTableService : BaseService
    {
        private IRepository<ExcelTable> excelTableRepository = null;
        public ExcelTableService()
        {
            excelTableRepository = new RepositoryBase<ExcelTable>();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>添加成功返回true，否则返回false</returns>
        public bool Add(ExcelTableDto entity)
        {
            var orderEntity = Mapper.Map<ExcelTableDto, ExcelTable>(entity);
            orderEntity.CredateTime = DateTime.Now;
            return excelTableRepository.Insert(orderEntity) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tpg">分页参数</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="dateFrom">创建时间</param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public List<ExcelTableDto> GetExcelTableGrid(TablePageParameter tpg, string excelName, DateTime? dateFrom, DateTime? dateTo)
        {
            Expression<Func<ExcelTable, bool>> ex = t => true;
            ex = ex.And(t => !t.IsDelete);
            if (!string.IsNullOrEmpty(excelName))
            {
                ex = ex.And(t => t.ExcelName.Contains(excelName));
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
            var excelTableList = excelTableRepository.GetEntities(ex);
            if (tpg == null)
            {
                return Mapper.Map<List<ExcelTable>, List<ExcelTableDto>>(excelTableList.ToList());
            }
            else
            {
                return Mapper.Map<List<ExcelTable>, List<ExcelTableDto>>(GetTablePagedList(excelTableList, tpg));
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Deletes(string ids)
        {
            int[] ida = ids.StrToIntArray();
            Expression<Func<ExcelTable, bool>> ex = t => true;
            ex = ex.And(t => !t.IsDelete);
            ex = ex.And(t => ida.Contains(t.Id));
            var excelList = excelTableRepository.GetEntities(ex).ToList();
            excelList.ForEach(zw =>
            {
                zw.IsDelete = true;
            });
            return excelTableRepository.Update(excelList) > 0;
        }

        public string GetLoadUrl(int id)
        {
            ExcelTable excelTable = excelTableRepository.Find(id);
            if (excelTable != null)
            {
                return excelTable.ExcelPath;
            }
            else
            {
                return "";
            }
        }
    }
}
