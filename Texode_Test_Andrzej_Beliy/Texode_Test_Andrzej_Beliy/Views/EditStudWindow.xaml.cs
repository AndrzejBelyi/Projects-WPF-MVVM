using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Texode_Test_Andrzej_Beliy.Views
{
    /// <summary>
    /// Логика взаимодействия для EditStudWindow.xaml
    /// </summary>
    public partial class EditStudWindow
    {
        public EditStudWindow()
        {
            InitializeComponent();
        }

        private void BtnAbort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
