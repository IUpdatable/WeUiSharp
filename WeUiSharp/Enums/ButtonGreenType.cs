using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeUiSharp.Enums
{
    public enum ButtonGreenType
    {
        /// <summary>
        /// 默认值，正常按钮，无绿色（Default, normal button, NO green）
        /// </summary>
        None = 0,
        /// <summary>
        /// 绿色文字按钮（Foreground is green）
        /// </summary>
        Foreground = 10,
        /// <summary>
        /// 仅当鼠标悬停时呈现绿色（Green only when the mouse is hovered）
        /// </summary>
        Hover = 20,
        /// <summary>
        /// 完全呈现绿色（Completely green）
        /// </summary>
        All = 30
    }
}
