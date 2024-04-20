using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Project_3942.Folder
{
    public class Module_Details
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public double Grade_Point { get; set; }
        public double Credit_Point { get; set; }
        public Module_Details(int id, string name, double credit_point)
        {
            Id = id;
            Name = name;
            Credit_Point = credit_point;
            Grade_Point = 0;
        }

    }
}
