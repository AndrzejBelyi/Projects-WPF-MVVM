using Mathilvania.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mathilvania.Views
{
    /// <summary>
    /// Логика взаимодействия для GameOverView.xaml
    /// </summary>
    public partial class GameOverView : Page
    {
        public GameOverView()
        {
            InitializeComponent();
            ViewModels.GameOverViewModel vm=(ViewModels.GameOverViewModel)this.DataContext;
            MainWindow mw = (MainWindow)App.Current.MainWindow;            
            if(vm.winner==vm.playerName)
            {
                LabelWinner.Content =vm.playerName+" WIN!";
                LabelWinner.Foreground = Brushes.RoyalBlue;
            }
            else
            {
                LabelWinner.Content ="YOU LOSE! HA!HA!";
                LabelWinner.Foreground = Brushes.Crimson;

            }
            Mathilvania.Models.Animations.GameOverMessegeAnimtion(LabelWinner);
        }
    }
}
