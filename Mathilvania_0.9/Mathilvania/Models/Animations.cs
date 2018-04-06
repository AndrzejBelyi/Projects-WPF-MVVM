using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Mathilvania.Models
{
   static class Animations
    {
        static public void trueAnswerAnimation(Button btn)
        {
           
            ColorAnimation buttonColorAnimation = new ColorAnimation();
            buttonColorAnimation.To = Colors.LimeGreen;
            buttonColorAnimation.AutoReverse = true;
            buttonColorAnimation.Duration = TimeSpan.FromSeconds(0.2);
            buttonColorAnimation.FillBehavior = FillBehavior.Stop;
            PowerEase pe = new PowerEase();
            pe.EasingMode = EasingMode.EaseOut;
            buttonColorAnimation.EasingFunction = pe;
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty,buttonColorAnimation);
           
           
        }
        static public void falseColorAnimation(Button btn)
        {
            ColorAnimation buttonColorAnimation = new ColorAnimation();
            buttonColorAnimation.To = Colors.Red;
            buttonColorAnimation.AutoReverse = true;
            buttonColorAnimation.Duration = TimeSpan.FromSeconds(0.2);
            buttonColorAnimation.FillBehavior = FillBehavior.Stop;
            PowerEase pe = new PowerEase();
            pe.EasingMode = EasingMode.EaseOut;
            buttonColorAnimation.EasingFunction = pe;
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty,buttonColorAnimation);
        }
       static public void onButtonGotFocusAnimtion(Button btn)
        {
            ScaleTransform trans = new ScaleTransform();
            btn.RenderTransform = trans;
            btn.RenderTransformOrigin =new Point(0.5,0.5);
            DoubleAnimation scaleAnimation = new DoubleAnimation(1,1.5,TimeSpan.FromMilliseconds(550),FillBehavior.HoldEnd);
            ElasticEase pe = new ElasticEase();
            pe.EasingMode = EasingMode.EaseOut;
            scaleAnimation.EasingFunction = pe;
            trans.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            trans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }
        static public void onButtonLostFocusAnimtion(Button btn)
        {
            ScaleTransform trans = new ScaleTransform();
            btn.RenderTransform = trans;
            btn.RenderTransformOrigin = new Point(0.5, 0.5);
            DoubleAnimation scaleAnimation = new DoubleAnimation(1.5,1, TimeSpan.FromMilliseconds(550), FillBehavior.HoldEnd);
            ElasticEase pe = new ElasticEase();
            pe.EasingMode = EasingMode.EaseOut;
            scaleAnimation.EasingFunction = pe;
            trans.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            trans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }
        static public void StartPlayerAnimation(Image image,Canvas canvas,int speed)
        {
            ThicknessAnimation enemyAnimation = new ThicknessAnimation();
            enemyAnimation.From = new Thickness(image.Margin.Left, 0, 0, 0);
            enemyAnimation.To = new Thickness(canvas.ActualWidth - image.ActualWidth, 0, 0, 0);
            enemyAnimation.Duration = TimeSpan.FromSeconds(speed);
            enemyAnimation.FillBehavior = FillBehavior.HoldEnd;
            image.BeginAnimation(Image.MarginProperty, enemyAnimation, HandoffBehavior.Compose);

        }
      static public void StartPlayerAnimation(Image image,Canvas canvas)
        {
            ThicknessAnimation playerAnimation = new ThicknessAnimation();
            playerAnimation.By = new Thickness(canvas.ActualWidth / 10, 0, 0, 0);
            playerAnimation.Duration = TimeSpan.FromSeconds(0.5);
            playerAnimation.FillBehavior = FillBehavior.HoldEnd;
            image.BeginAnimation(Image.MarginProperty, playerAnimation, HandoffBehavior.Compose);
        }
        static public void GameOverMessegeAnimtion(Label label)
        {
            ScaleTransform trans = new ScaleTransform();
            label.RenderTransform = trans;
            label.RenderTransformOrigin = new Point(0.5, 0.5);
            DoubleAnimation scaleAnimation = new DoubleAnimation(1, 1.4, TimeSpan.FromMilliseconds(900), FillBehavior.Stop);
            scaleAnimation.AutoReverse = true;
            scaleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            ElasticEase pe = new ElasticEase();
            pe.EasingMode = EasingMode.EaseInOut;
            scaleAnimation.EasingFunction = pe;
            trans.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            trans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }

    }
}
