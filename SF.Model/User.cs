using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User")]
    public class User : BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string LogingName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [MaxLength(10)]
        public string Status { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
