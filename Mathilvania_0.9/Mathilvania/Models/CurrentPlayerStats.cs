namespace Mathilvania.Models
{
    public class CurrentPlayerStats
    {
        public string playerName { get; set; }
        public uint countTrueAnswers { get; set; }
        public uint countFalseAnswers { get; set; }
        public uint countQuestions { get; set; }
        public uint PlayTime { get; set; }
       public CurrentPlayerStats(string playerName)
        {
            this.playerName = playerName;
            countQuestions = 0;
            countTrueAnswers = 0;
            countFalseAnswers = 0;
            PlayTime = 0;
        }

    }
}
