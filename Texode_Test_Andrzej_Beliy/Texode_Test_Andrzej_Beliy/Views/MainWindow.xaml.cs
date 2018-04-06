using System.Windows;
using Texode_Test_Andrzej_Beliy.Views;
using MahApps.Metro.Controls;

namespace Texode_Test_Andrzej_Beliy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addWindow = new AddStudentWindow();
            addWindow.Left = (int)(this.Width / 2);
            addWindow.Top=this.Top+30;
            addWindow.ShowDialog();
        }        

        private void BtnEditClick(object sender, RoutedEventArgs e)
        {
            EditStudWindow editWindow = new EditStudWindow();
            editWindow.Left = (int)(this.Width / 2);
            editWindow.Top = this.Top + 30;
            editWindow.ShowDialog();
        }
    }
}
