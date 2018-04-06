using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
    public class Question:MathExpression
    {
        public int firstNumb { get;private set; }
        public int secondNumb { get;private set; }
        public char operation { get;private set; }
        public int trueResult { get;private set; }
        public List<int> listOfAnswers { get;private set; }
        public Question(int n, int m, bool addition, bool substract, bool multiplication, bool negativeNumber) : base(n, m, addition, substract, multiplication, negativeNumber)
        {
            newQuestion();
        }
        public void newQuestion()
        {      
            operation = getRandomOperation();
            firstNumb = getRandomIntNumb();
            secondNumb = getRandomIntNumb();
            trueResult = GetTrueResult();
            listOfAnswers = getRandomListOfAnswers();
        }
        private char getRandomOperation()
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            char rndoperation = getListOfOperations()[rand.Next(getListOfOperations().Count)];
            return rndoperation;
        }
        private int getRandomIntNumb()
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
           
            if(negativeNumber)
            {
                return (int)(rand.Next(minNumb,maxNumb) * Math.Pow((double)-1, (double)rand.Next(2)));
            }
            else
            {
                return rand.Next(minNumb,maxNumb);
            }
        }
        public int GetTrueResult()
        {
            int truerusult = 0;
            if (operation == '+')
            {
                truerusult = firstNumb + secondNumb;
            }
            if (operation == '-')
            {
                truerusult = firstNumb - secondNumb;
            }
            if (operation == '*')
            {
                truerusult = firstNumb * secondNumb;
            }
            return truerusult;
        }
        public int getFalseResult()
        {
            int falseresult = 0;
            while(true)
            {
                if (operation == '+')
                {
                    falseresult = getRandomIntNumb() + getRandomIntNumb();
                }
                if (operation == '-')
                {
                    falseresult = getRandomIntNumb() - getRandomIntNumb();
                }
                if (operation == '*')
                {
                    falseresult = getRandomIntNumb() * getRandomIntNumb();
                }

                if (falseresult != this.trueResult)
                    break;
            }
            return falseresult;
        }
        private List<int> getRandomListOfAnswers()
        {
            List<int> list = new List<int>(4);
            while (true)
            {
                list.Add(getFalseResult());
                if (list.Count == 4)
                    break;
            }
            var rand = new Random(Guid.NewGuid().GetHashCode());
            list.Insert(rand.Next(4),trueResult);
            return list;
        }
        public bool isTrueAnswer(string parameter)
        {
            bool result = false;
            if (parameter == trueResult.ToString())
            {
                result = true;
            }
            return result;
        }
    }
}