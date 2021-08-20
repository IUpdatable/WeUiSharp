using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeUiSharp.Windows
{
    public enum MessageBoxButton
    {
        /// <summary>
        /// 该消息框显示 确定 按钮。
        /// </summary>
        OK = 0,
        /// <summary>
        /// 该消息框显示 确定 和 取消 按钮。
        /// </summary>
        OKCancel = 1,
        /// <summary>
        /// 该消息框显示 是, ，否, ，和 取消 按钮。
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// 该消息框显示 是 和 否 按钮。
        /// </summary>
        YesNo = 4,
        /// <summary>
        /// 该消息框显示 我知道了 按钮。
        /// </summary>
        GotIt = 5,
    }
}
