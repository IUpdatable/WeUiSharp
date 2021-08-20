using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeUiSharp.Windows
{
    public class MessageBox
    {
        public MessageBox()
        {
            
        }
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            MessageBoxResult result = MessageBoxResult.Cancel;
            using (MessageBoxWrapper messageBox = new MessageBoxWrapper())
            {
                messageBox.Title = caption;
                messageBox.Message = messageBoxText;
                messageBox.MessageBoxButton = button;
                messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                messageBox.Owner = Application.Current.MainWindow;
                messageBox.ShowDialog();
                result = messageBox.Result;
            }
            return result;
        }
        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return Show(messageBoxText, caption, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(string messageBoxText)
        {
            return Show(messageBoxText, "", MessageBoxButton.OK);
        }
    }
}
