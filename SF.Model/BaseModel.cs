﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Model
{
    [Serializable]
    public abstract class BaseModel
    {
        /// <summary>
        /// 主键ID（自增）
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CredateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [MaxLength(50)]
        public string UpdateUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
