using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Texode_Test_Andrzej_Beliy.Services;

namespace Texode_Test_Andrzej_Beliy.Models
{
    public class ListOfStudents : ObservableCollection<Student>
    {
       public ListOfStudents()
        {
           foreach(Student stud in InputOutputXmlFile.getStudListFromFile())
            {
                this.Add(stud);
            }                
        }
        public void AddStudent(Student stud)
        {
            this.Add(stud);
            InputOutputXmlFile.AddStudToFile(stud);
        }
        public void EditStudent(Student stud,int index)
        {
            this[index] = stud;
            this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(
           System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
            InputOutputXmlFile.ReplaceStudent(stud, index);
        }
        public void DeleteStud(int index)
        {
            this.RemoveAt(index);
            InputOutputXmlFile.DeleteStudentFromFile(index);
        }
    }
}
