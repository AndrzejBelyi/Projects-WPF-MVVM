using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texode_Test_Andrzej_Beliy.Models
{
    public class Gender
    {
        public Gender()
        {
            Id = 0;
            Value = "null";
        }
        public uint Id { get; set; }
        public string Value { get; set; }
        static public List<Gender> getListOfGender()
        {
            List<Gender> listOfGender = new List<Gender>();
            listOfGender.Add(new Gender { Id = 0, Value = "М" });
            listOfGender.Add(new Gender { Id = 1, Value = "Ж" });

            return listOfGender;
        }
    }
}
