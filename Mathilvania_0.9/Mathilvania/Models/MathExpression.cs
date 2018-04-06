using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
   public class  MathExpression
    {
        private int  _minNumb;
        private int  _maxNumb;
        private bool _addition;
        private bool _subtract;
        private bool _multiplication;
        private bool _negativeNumber;
        public int minNumb { get { return _minNumb; } }
        public int maxNumb { get { return _maxNumb; } }
        protected bool negativeNumber
        {
            get
            {
               return _negativeNumber;
            }
            set
            {
                _negativeNumber = value;
            }
        }

        public MathExpression(int n,int m,bool addition,bool substract,bool multiplication,bool negativeNumber)
        {
            _minNumb = n;
            _maxNumb = m;
            _addition = addition;
            _subtract = substract;
            _multiplication = multiplication;
            _negativeNumber = negativeNumber;
        }    
        protected List<char> getListOfOperations()
        {
            List<char> listOfOperations = new List<char>();
            if (_addition)
            {
               listOfOperations.Add('+');
            }
            if (_subtract)
            {
                listOfOperations.Add('-');
            }
            if (_multiplication)
            {
                listOfOperations.Add('*');
            }
            return listOfOperations;
        }

    }
}
