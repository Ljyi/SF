using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    [Table("Order")]
    public class Order : BaseModel
    {
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
        public int Status { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }
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
        /// 系统用户Id
        /// </summary>
      //  public int UserId { get; set; }
    }
}
