using System;
using System.ComponentModel.DataAnnotations;

namespace SF.Model.DataModelDto
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string OrderNo { get; set; }
        /// <summary>
        /// 手机号
        /// </summary> 
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 渠道号
        /// </summary>
        [Required]
        public int Channel { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CredateTime { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(20)]
        public string Remark { get; set; }
    }
    /// <summary>
    /// 订单导入
    /// </summary>
    public class OrderApiDto
    {
        ///// 1：立刷
        ///// 2：鼎刷
        ///// 3：考拉
        ///// 4：通联
        ///// 5：银盛通
        ///// 6：POS

        /// <summary>
        /// 渠道号
        /// 7：付临门
        /// </summary>
        [Required]
        public int Channel { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary> 
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(20)]
        public string Remark { get; set; }
    }
}
