using System.ComponentModel;

namespace SF.Model.EnumModel
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatusEnum
    {

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        NorMal = 0,
        /// <summary>
        /// 考虑中
        /// </summary>
        [Description("考虑中")]
        ConsiderIng = 1,
        /// <summary>
        /// 联系不上
        /// </summary>
        [Description("联系不上")]
        NoConnection = 2,
        /// <summary>
        /// 不要了
        /// </summary>
        [Description("不要了")]
        NoMore = 3,
        /// <summary>
        /// 已发货
        /// </summary>
        [Description("已发货")]
        Shipped = 4,
    }
}
