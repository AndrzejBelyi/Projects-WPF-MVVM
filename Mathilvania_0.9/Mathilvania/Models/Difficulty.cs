using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathilvania.Models
{
   public class Difficulty
    {
           public Difficulty()
            {
                Id = 0;
                Value = "null";
            }
            public int Id { get; set; }
            public string Value { get; set; }
       static public List<Difficulty> getListOfDifficulty()
        {
            List<Difficulty> listOfDifficulty = new List<Difficulty>();
            listOfDifficulty.Add(new Difficulty { Id = 0, Value = "Младенец" });
            listOfDifficulty.Add(new Difficulty { Id = 1, Value = "Новичок" });
            listOfDifficulty.Add(new Difficulty { Id = 2, Value = "Обычный" });
            listOfDifficulty.Add(new Difficulty { Id = 3, Value = "Сложный" });
            listOfDifficulty.Add(new Difficulty { Id = 4, Value = "Безумный" });
            listOfDifficulty.Add(new Difficulty { Id = 5, Value = "Невыносимый" });
            listOfDifficulty.Add(new Difficulty { Id = 6, Value = "Песочница" });

            return listOfDifficulty;
        }
    }
}
