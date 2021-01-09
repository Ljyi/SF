using System;
using System.ComponentModel.DataAnnotations;

namespace SF.Model.DataModelDto
{
    public class ExcelTableDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Excel名称
        /// </summary>
        [MaxLength(250)]
        [Required]
        public string ExcelName { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string ExcelPath { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public DateTime CredateTime { get; set; }
    }
}
