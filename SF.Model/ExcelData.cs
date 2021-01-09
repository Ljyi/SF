using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Model
{
    [Table("ExcelTable")]
    public class ExcelTable : BaseModel
    {
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
    }
}
