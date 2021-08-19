using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeUiSharp.Windows
{
    public enum MessageBoxResult
    {
        /// <summary>
        /// 消息框中不返回任何结果。
        /// </summary>
        None = 0,
        /// <summary>
        /// 消息框中不返回任何结果。
        /// </summary>
        OK = 1,
        /// <summary>
        /// 消息框的结果值 取消。
        /// </summary>
        Cancel = 2,
        /// <summary>
        /// 消息框的结果值 是。
        /// </summary>
        Yes = 6,
        /// <summary>
        /// 消息框的结果值 否。
        /// </summary>
        No = 7,
        /// <summary>
        /// 消息框的结果值 我知道了。
        /// </summary>
        GotIt = 5,
    }
}
