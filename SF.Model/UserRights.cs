using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    /// <summary>
    /// 用户权限
    /// </summary>
    [Table("UserRights")]
    public class UserRights : BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        [Required]
        public int SysMenuId { get; set; }
        public virtual SysMenu SysMenu { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
