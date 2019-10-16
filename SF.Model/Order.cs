using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// 主键ID（自增）
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string OrderNo { get; set; }
        /// <summary>
        /// 渠道号
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
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }
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
        /// <summary>
        /// 更新人
        /// </summary>
        [MaxLength(20)]
        public string UpdateUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
