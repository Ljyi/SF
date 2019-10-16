using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Table("UserRole")]
    public class UserRole : BaseModel
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
