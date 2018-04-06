using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Mathilvania.Models
{
    public class OnePlayerGameOptionsMessege:MessageBase
    {
        public int speedEnemy { get; set; }
        public int minNumb { get; set; }
        public int maxNumb { get; set; }

        public bool additionChecked { get; set; }
        public bool substractChecked { get; set; }
        public bool multiplicationChecked { get; set; }
        public bool negativeNumberChecked { get; set; }
      public  OnePlayerGameOptionsMessege()
        {

        }
       
        
    }
}
