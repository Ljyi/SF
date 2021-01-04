using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model.DataModelDto
{

    public class ImportModel
    {
        public int 渠道 { get; set; }
        public string 订单号 { get; set; }
        public string 姓名 { get; set; }
        public string 手机号 { get; set; }
        public string 地址 { get; set; }
        public string 日期 { get; set; }
        public string 时间 { get; set; }
        public string 备注 { get; set; }
    }
}
