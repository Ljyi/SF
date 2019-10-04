using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    [Table("Role")]
    public class Role : BaseModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Status { get; set; }
    }
}
