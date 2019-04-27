using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VisualNovelManagerCore.Helper.Extensions
{
    public class PasswordBoxBindingBehavior
    {
        private void OnPasswordBoxValueChanged(object sender, RoutedEventArgs e)
        {
            try{}
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw new NotImplementedException();
            }
        }
    }
}
