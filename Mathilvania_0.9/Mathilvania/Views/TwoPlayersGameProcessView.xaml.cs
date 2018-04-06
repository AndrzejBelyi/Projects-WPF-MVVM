using Mathilvania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для TwoPlayersGameProcessView.xaml
    /// </summary>
    public partial class TwoPlayersGameProcessView : Page
    {
        ViewModels.TwoPlayersGameProcessViewModel vm;
        public SoundPlayer player= new SoundPlayer("Resources/Click.wav");
        public TwoPlayersGameProcessView()
        {
            InitializeComponent();
            vm = (ViewModels.TwoPlayersGameProcessViewModel)this.DataContext;
            vm.Initialize();
            Loaded += delegate { vm.OnLoaded(); };
            Unloaded += delegate { vm.UnLoaded(); };
            button1.Focus();
       
            vm.PropertyChanged += (e, args) =>
            {
                if ((args.PropertyName == "player1StartAnimationFlag") && (vm.player1StartAnimationFlag == true))
                {
                    Animations.StartPlayerAnimation(imagePlayer1, mainCanvas);
                }
                if ((args.PropertyName == "player2StartAnimationFlag") && (vm.player2StartAnimationFlag == true))
                {
                    Animations.StartPlayerAnimation(imagePlayer2, mainCanvas);
                }
            };
        }
        public void btnKeyUp(object sender, KeyEventArgs e)
        {
            
           switch (e.Key)
            {
                case Key.D1:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button1);                    
                    btnPlayer1_Click(button1, null);
                    vm.BtnPlayer1_Click.Execute(button1.Content);
                    Animations.onButtonLostFocusAnimtion(button1);
                    break;
                case Key.D2:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button2);
                    btnPlayer1_Click(button2, null);
                    vm.BtnPlayer1_Click.Execute(button2.Content);
                    Animations.onButtonLostFocusAnimtion(button2);
                    break;
                case Key.D3:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button3);
                    btnPlayer1_Click(button3, null);
                    vm.BtnPlayer1_Click.Execute(button3.Content);
                    Animations.onButtonLostFocusAnimtion(button3);
                    break;
                case Key.D4:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button4);
                    btnPlayer1_Click(button4, null);
                    vm.BtnPlayer1_Click.Execute(button4.Content);
                    Animations.onButtonLostFocusAnimtion(button4);
                    break;
                case Key.U:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button1);
                    btnPlayer2_Click(button1, null);
                    vm.BtnPlayer2_Click.Execute(button1.Content);
                    Animations.onButtonLostFocusAnimtion(button1);
                    break;
                case Key.I:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button2);
                    btnPlayer2_Click(button2, null);
                    vm.BtnPlayer2_Click.Execute(button2.Content);
                    Animations.onButtonLostFocusAnimtion(button2);
                    break;
                case Key.O:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button3);
                    btnPlayer2_Click(button3, null);
                    vm.BtnPlayer2_Click.Execute(button3.Content);
                    Animations.onButtonLostFocusAnimtion(button3);
                    break;
                case Key.P:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button4);
                    btnPlayer2_Click(button4, null);
                    vm.BtnPlayer2_Click.Execute(button4.Content);
                    Animations.onButtonLostFocusAnimtion(button4);
                    break;
                default:
                    
                    break;           
            }
        }
        private void btnPlayer1_Click(object sender, RoutedEventArgs e)
        {
            if (vm._question.isTrueAnswer((sender as Button).Content.ToString()))
            {
                Animations.trueAnswerAnimation(sender as Button);
            }
            else
            {
                Animations.falseColorAnimation(sender as Button);
            }
        }
        private void btnPlayer2_Click(object sender, RoutedEventArgs e)
        {
            if (vm._question.isTrueAnswer((sender as Button).Content.ToString()))
            {
                Animations.trueAnswerAnimation(sender as Button);
            }
            else
            {
                Animations.falseColorAnimation(sender as Button);
            }
        }
        
    }
}
