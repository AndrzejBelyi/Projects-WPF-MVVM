using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Mathilvania.Models
{
   public partial class ResourceDictionaryHandlers
    {
        
        public void button_MouseEnter(object sender, MouseEventArgs e)
        {
            new SoundPlayer("Resources/Swoosh2.wav").Play();
            Animations.onButtonGotFocusAnimtion(sender as Button);
        }

       public void button_MouseLeave(object sender, MouseEventArgs e)
        {
            new SoundPlayer("Resources/Swoosh2.wav").Play();
            Animations.onButtonLostFocusAnimtion(sender as Button);
        }
        public void button_Click(object sender,RoutedEventArgs e)
        {
            new SoundPlayer("Resources/Click2.wav").Play();
        }
    }
}
