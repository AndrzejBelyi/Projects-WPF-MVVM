using System;
using System.Collections.ObjectModel;
using System.Xml;
using Texode_Test_Andrzej_Beliy.Models;

namespace Texode_Test_Andrzej_Beliy.Services
{
    static class InputOutputXmlFile
    {
        static public ObservableCollection<Student> getStudListFromFile()
        {
            ObservableCollection<Student> studlist = new ObservableCollection<Student>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Students.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Student stud = new Student();
                XmlNode attr = xnode.Attributes.GetNamedItem("Id");
                if (attr != null)
                    stud.id = int.Parse(attr.Value);
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "FirstName":
                            {
                                stud.firstName = childnode.InnerText;
                                break;
                            }
                        case "Last":
                            {
                                stud.lastName = childnode.InnerText;
                                break;
                            }
                        case "Age":
                            {
                                stud.age = UInt16.Parse(childnode.InnerText);
                                break;
                            }
                        case "Gender":
                            {
                                stud.gender = UInt16.Parse(childnode.InnerText);
                                break;
                            }

                        default: break;
                    }
                }
                studlist.Add(stud);
            }
            return studlist;
        }
        static public void AddStudToFile(Student stud)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Students.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement userElem = xDoc.CreateElement("Student");
            XmlAttribute IdAttr = xDoc.CreateAttribute("Id");
            XmlElement FirstNameElem = xDoc.CreateElement("FirstName");
            XmlElement LastNameElem = xDoc.CreateElement("Last");
            XmlElement AgeElem = xDoc.CreateElement("Age");
            XmlElement GenderElem = xDoc.CreateElement("Gender");

            XmlText IdText = xDoc.CreateTextNode(stud.id.ToString());
            XmlText FirstNameText = xDoc.CreateTextNode(stud.firstName.ToString());
            XmlText LastNameText = xDoc.CreateTextNode(stud.lastName.ToString());
            XmlText AgeText = xDoc.CreateTextNode(stud.age.ToString());
            XmlText GenderText = xDoc.CreateTextNode(stud.gender.ToString());

            IdAttr.AppendChild(IdText);
            FirstNameElem.AppendChild(FirstNameText);
            LastNameElem.AppendChild(LastNameText);
            AgeElem.AppendChild(AgeText);
            GenderElem.AppendChild(GenderText);
            xRoot.AppendChild(userElem);
            userElem.Attributes.Append(IdAttr);
            userElem.AppendChild(FirstNameElem);
            userElem.AppendChild(LastNameElem);
            userElem.AppendChild(AgeElem);
            userElem.AppendChild(GenderElem);
            xDoc.Save("Students.xml");
        }

        static private void fillFileFromList(ObservableCollection<Student> studlist)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Students.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            xRoot.RemoveAll();
            foreach (Student stud in studlist)
            {
                XmlElement userElem = xDoc.CreateElement("Student");
                XmlAttribute IdAttr = xDoc.CreateAttribute("Id");
                XmlElement FirstNameElem = xDoc.CreateElement("FirstName");
                XmlElement LastNameElem = xDoc.CreateElement("Last");
                XmlElement AgeElem = xDoc.CreateElement("Age");
                XmlElement GenderElem = xDoc.CreateElement("Gender");

                XmlText IdText = xDoc.CreateTextNode(stud.id.ToString());
                XmlText FirstNameText = xDoc.CreateTextNode(stud.firstName.ToString());
                XmlText LastNameText = xDoc.CreateTextNode(stud.lastName.ToString());
                XmlText AgeText = xDoc.CreateTextNode(stud.age.ToString());
                XmlText GenderText = xDoc.CreateTextNode(stud.gender.ToString());

                IdAttr.AppendChild(IdText);
                FirstNameElem.AppendChild(FirstNameText);
                LastNameElem.AppendChild(LastNameText);
                AgeElem.AppendChild(AgeText);
                GenderElem.AppendChild(GenderText);
                xRoot.AppendChild(userElem);
                userElem.Attributes.Append(IdAttr);
                userElem.AppendChild(FirstNameElem);
                userElem.AppendChild(LastNameElem);
                userElem.AppendChild(AgeElem);
                userElem.AppendChild(GenderElem);
            }
            xDoc.Save("Students.xml");
        }
        static public void DeleteStudentFromFile(int index)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Students.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            //xDoc.DocumentElement.RemoveChild(xDoc.DocumentElement.ChildNodes[index]);
            xRoot.RemoveChild(xRoot.ChildNodes.Item(index));
            xDoc.Save("Students.xml");
        }

        static public void ReplaceStudent(Student stud,int index)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Students.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement userElem = xDoc.CreateElement("Student");
            XmlAttribute IdAttr = xDoc.CreateAttribute("Id");
            XmlElement FirstNameElem = xDoc.CreateElement("FirstName");
            XmlElement LastNameElem = xDoc.CreateElement("Last");
            XmlElement AgeElem = xDoc.CreateElement("Age");
            XmlElement GenderElem = xDoc.CreateElement("Gender");

            XmlText IdText = xDoc.CreateTextNode(stud.id.ToString());
            XmlText FirstNameText = xDoc.CreateTextNode(stud.firstName.ToString());
            XmlText LastNameText = xDoc.CreateTextNode(stud.lastName.ToString());
            XmlText AgeText = xDoc.CreateTextNode(stud.age.ToString());
            XmlText GenderText = xDoc.CreateTextNode(stud.gender.ToString());

            IdAttr.AppendChild(IdText);
            FirstNameElem.AppendChild(FirstNameText);
            LastNameElem.AppendChild(LastNameText);
            AgeElem.AppendChild(AgeText);
            GenderElem.AppendChild(GenderText);
            xRoot.AppendChild(userElem);
            userElem.Attributes.Append(IdAttr);
            userElem.AppendChild(FirstNameElem);
            userElem.AppendChild(LastNameElem);
            userElem.AppendChild(AgeElem);
            userElem.AppendChild(GenderElem);

            xRoot.ReplaceChild(userElem, xRoot.ChildNodes.Item(index));
            xDoc.Save("Students.xml");
        }

    }
}
