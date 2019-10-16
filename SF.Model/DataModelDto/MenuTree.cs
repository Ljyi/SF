using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuTree
    {
        public MenuTree()
        {
            menuTrees = new List<MenuTree>();
        }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单级别
        /// </summary>
        public int MenuLevel { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNumber { get; set; }
        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        ///子菜单
        /// </summary>
        public List<MenuTree> menuTrees { get; set; }
    }
}
