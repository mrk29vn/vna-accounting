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
    /// Interaction logic for ucBaoCaoTonKho.xaml
    /// </summary>
    public partial class ucBaoCaoTonKho : UserControl
    {
        public ucBaoCaoTonKho()
        {
            InitializeComponent();
            imgbaocao.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"/Images/BaoCao_icon.png"));

            //Show or Hide XNT
            Visibility configXnt = Utils.ShowXnt ? Visibility.Visible : Visibility.Hidden;
            bcXNTTheoNhomHang.Visibility = configXnt;
            bcXNTTheoPhieuXuatHuy.Visibility = configXnt;
            bcXNTTheoLoaiHang.Visibility = configXnt;
            bcXNTTheoKho.Visibility = configXnt;
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
