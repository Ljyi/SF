using System.ComponentModel;

namespace SF.Model.EnumModel
{
    /// <summary>
    /// 渠道号
    /// </summary>
    public enum ChannelEnum
    {
        /// <summary>
        /// 立刷
        /// </summary>
        [Description("立刷")]
        VerticalBrush = 1,
        /// <summary>
        /// 鼎刷
        /// </summary>
        [Description("鼎刷")]
        TripodBrush = 2,
        /// <summary>
        /// 考拉
        /// </summary>
        [Description("考拉")]
        Koala = 3,
        /// <summary>
        /// 通联
        /// </summary>
        [Description("通联")]
        UnitedEffort = 4,
        /// <summary>
        /// 银盛通
        /// </summary>
        [Description("银盛通")]
        ShengTong = 5,
        /// <summary>
        /// Pos
        /// </summary>
        [Description("POS")]
        POS = 6,
        /// <summary>
        /// Pos
        /// </summary>
        [Description("FLM")]
        FLM = 7
    }
}
