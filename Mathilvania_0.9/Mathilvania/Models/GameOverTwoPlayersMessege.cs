using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
    class GameOverTwoPlayersMessege
    {
        public string winner { get; set; }
        public uint playTime { get; set; }
        public uint countPlayer1TrueAnswers { get; set; }
        public uint countPlayer1FalseAnswers { get; set; }
        public uint countPlayer1Questions { get; set; }
        public uint countPlayer2TrueAnswers { get; set; }
        public uint countPlayer2FalseAnswers { get; set; }
        public uint countPlayer2Questions { get; set; }
    }
}
