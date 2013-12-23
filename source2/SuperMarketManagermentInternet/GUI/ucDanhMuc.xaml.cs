using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ucDanhMuc.xaml
    /// </summary>
    public partial class ucDanhMuc : UserControl
    {
        public ucDanhMuc()
        {
            InitializeComponent(); try
            {
                imgDanhMuc.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/DanhMuc_icon.png"));
            }
            catch
            {
            }
        }

        private void img_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                new Common.Utilities().Themes_MouseLeave(sender);
            }
            catch
            {
            }
        }
        private void img_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                new Common.Utilities().Themes_MouseMove(sender);
            }
            catch
            {
            }
        }
        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                new Common.Utilities().Themes_MouseLeave(sender);
            }
            catch
            {
            }
        }
    }
}
