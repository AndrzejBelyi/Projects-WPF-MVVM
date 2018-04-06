using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mathilvania.Models;
using System.Media;

namespace Mathilvania.Views
{
    /// <summary>
    /// Логика взаимодействия для OnePlayerGameProcessView.xaml
    /// </summary>
    public partial class OnePlayerGameProcessView : Page
    {
        private int speedEnemy;
        ViewModels.OnePlayerGameProcessViewModel vm;
        public SoundPlayer player = new SoundPlayer("Resources/Click.wav");
        public OnePlayerGameProcessView()
        {
            InitializeComponent();
            vm = (ViewModels.OnePlayerGameProcessViewModel)this.DataContext;
            vm.Initialize();
            Loaded += delegate { vm.OnLoaded();};
            Unloaded += delegate {vm.UnLoaded();};
            button1.Focus();
            this.speedEnemy = vm.enemySpeed;
            vm.PropertyChanged += (e, args) =>
            {
                if ((args.PropertyName == "startEnemyAnimationFlag") && (vm.startEnemyAnimationFlag == true))
                {
                  Animations.StartPlayerAnimation(imageEnemy,mainCanvas,speedEnemy);
                }
                if ((args.PropertyName == "startPlayerAnimationFlag") && (vm.startPlayerAnimationFlag == true))
                {
                  Animations.StartPlayerAnimation(imagePlayer,mainCanvas);
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
                    btn_Click(button1, null);
                    vm.Btn_Click.Execute(button1.Content);
                    Animations.onButtonLostFocusAnimtion(button1);
                    break;
                case Key.D2:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button2);
                    btn_Click(button2, null);
                    vm.Btn_Click.Execute(button2.Content);
                    Animations.onButtonLostFocusAnimtion(button2);
                    break;
                case Key.D3:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button3);
                    btn_Click(button3, null);
                    vm.Btn_Click.Execute(button3.Content);
                    Animations.onButtonLostFocusAnimtion(button3);
                    break;
                case Key.D4:
                    player.Play();
                    Animations.onButtonGotFocusAnimtion(button4);
                    btn_Click(button4, null);
                    vm.Btn_Click.Execute(button4.Content);
                    Animations.onButtonLostFocusAnimtion(button4);
                    break;
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
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