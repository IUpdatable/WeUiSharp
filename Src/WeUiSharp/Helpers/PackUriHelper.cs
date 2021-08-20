using System;

namespace WeUiSharp
{
    internal static class PackUriHelper
    {
        public static Uri GetAbsoluteUri(string path)
        {
            return new Uri($"pack://application:,,,/WeUiSharp;component/{path}");
        }
    }
}
