using Mathilvania.Models;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mathilvania.Views
{
    /// <summary>
    /// Логика взаимодействия для TwoPlayersGameProcess2.xaml
    /// </summary>
    public partial class TwoPlayersGameProcessSplitModeView : Page
    {
        ViewModels.TwoPlayersGameProcessSplitModeViewModel vm;
        public SoundPlayer player = new SoundPlayer("Resources/Click.wav");
        public TwoPlayersGameProcessSplitModeView()
        {
            InitializeComponent();
            vm = (ViewModels.TwoPlayersGameProcessSplitModeViewModel)this.DataContext;
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
                    vm.Btn_Player1Click.Execute(button1.Content);
                    Animations.onButtonLostFocusAnimtion(button1);
                    break;
                case Key.D2:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button2);
                    btnPlayer1_Click(button2, null);
                    vm.Btn_Player1Click.Execute(button2.Content);
                    Animations.onButtonLostFocusAnimtion(button2);
                    break;
                case Key.D3:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button3);
                    btnPlayer1_Click(button3, null);
                    vm.Btn_Player1Click.Execute(button3.Content);
                    Animations.onButtonLostFocusAnimtion(button3);
                    break;
                case Key.D4:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button4);
                    btnPlayer1_Click(button4, null);
                    vm.Btn_Player1Click.Execute(button4.Content);
                    Animations.onButtonLostFocusAnimtion(button4);
                    break;
                case Key.U:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button5);
                    btnPlayer2_Click(button5, null);
                    vm.Btn_Player2Click.Execute(button5.Content);
                    Animations.onButtonLostFocusAnimtion(button5);
                    break;
                case Key.I:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button6);
                    btnPlayer2_Click(button6, null);
                    vm.Btn_Player2Click.Execute(button6.Content);
                    Animations.onButtonLostFocusAnimtion(button6);
                    break;
                case Key.O:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button7);
                    btnPlayer2_Click(button7, null);
                    vm.Btn_Player2Click.Execute(button7.Content);
                    Animations.onButtonLostFocusAnimtion(button7);
                    break;
                case Key.P:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button8);
                    btnPlayer2_Click(button8, null);
                    vm.Btn_Player2Click.Execute(button8.Content);
                    Animations.onButtonLostFocusAnimtion(button8);
                    break;
            }
        }
        private void btnPlayer1_Click(object sender, RoutedEventArgs e)
        {
            if (vm._question1.isTrueAnswer((sender as Button).Content.ToString()))
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
            if (vm._question2.isTrueAnswer((sender as Button).Content.ToString()))
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

