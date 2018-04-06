using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
   public class GeneralPlayerStats
    {
        public TimeSpan playngTime { get; set; }
        public uint countQuestions { get; set; }
        public uint countTrueAnswers { get; set; }
        public uint countFalseAnswers { get; set; }
        public uint countGames { get; set; }
        public uint countWin { get; set; }
        public uint countLose { get; set; }
       public GeneralPlayerStats()
       {
           
       }
        private List<string> getStringStats()
        {
            List<string> listStats = new List<string>
            {
                playngTime.ToString(),
                countQuestions.ToString(),
                countTrueAnswers.ToString(),
                countFalseAnswers.ToString(),
                countGames.ToString(),
                countWin.ToString(),
                countLose.ToString()
            };
            return listStats;
        }
       public void WriteStats()
        {
            File.WriteAllLines("./Resources/MathilvaniaStats.txt",getStringStats());
        }
        public void ReadStats()
        {
            if (File.Exists("./Resources/MathilvaniaStats.txt"))
            {
                List<string> listOfStats = File.ReadAllLines("./Resources/MathilvaniaStats.txt").ToList();
                playngTime = TimeSpan.Parse(listOfStats[0]);
                countQuestions = UInt32.Parse(listOfStats[1]);
                countTrueAnswers = UInt32.Parse(listOfStats[2]);
                countFalseAnswers = UInt32.Parse(listOfStats[3]);
                countGames = UInt32.Parse(listOfStats[4]);
                countWin = UInt32.Parse(listOfStats[5]);
                countLose = UInt32.Parse(listOfStats[6]);
            }
        }
        public void ClearStats()
        {
            if (File.Exists("./Resources/MathilvaniaStats.txt"))
            {
                playngTime = TimeSpan.Zero;
                countQuestions = 0;
                countTrueAnswers = 0;
                countFalseAnswers = 0;
                countGames = 0;
                countWin = 0;
                countLose = 0;
                WriteStats();
            }

        } 
    }
}
