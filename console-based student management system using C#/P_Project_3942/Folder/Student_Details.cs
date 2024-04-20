using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P_Project_3942.Folder
{
    public class Student_Details
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public string Address { get; set; }
        public List<Module_Details> Modules = new List<Module_Details>();
        public Student_Details(int id, string firstName, string lastName, string dateOfBirth, string address)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;

        }
        public double GPA_Value(Student_Details user)
        {
            double Point = 0;
            double Sum_of_Credits = 0.000000000001;

            foreach (var mode in user.Modules)
            {
                Point = Point + (mode.Grade_Point) * (mode.Credit_Point);
                Sum_of_Credits = Sum_of_Credits + mode.Credit_Point;
            }
            double GPA = Point / Sum_of_Credits;

            return GPA;

        }







    }
}
