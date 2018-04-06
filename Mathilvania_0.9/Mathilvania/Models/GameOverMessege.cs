using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
    class GameOverMessege
    {
        public string playerName { get; set; }
        public string winner { get; set; }
        public uint playTime{ get; set; }
        public uint countTrueAnswers { get; set; }
        public uint countFalseAnswers { get; set; }
        public uint countQuestions { get; set; }
    }
}
