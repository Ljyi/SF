using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model.DataModelDto
{
    /// <summary>
    /// 实体
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// 新建实体时使用
        /// </summary>
        /// <returns>返回新建的实体</returns>
        public static RoleDto New()
        {
            RoleDto role = new RoleDto()
            {
            };
            return role;
        }
        //#region 需持久化属性

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        public string Status { get; set; }

    }
}
