using P_Project_3942.Folder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P_Project_3942
{
    public static class List_Of_Data
    {
        public static List<Student_Details> users = new List<Student_Details>();
        public static int studentId = 1001;

        public static void Adding_New_User()
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"New User ID: {studentId} ");

            Console.CursorVisible = true;
            Console.Write("Enter The First Name of User: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter The Last Name of  User: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter The Date of Birth of User [ DD/MM/YEAR ]: ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter The Address of User: ");
            string address = Console.ReadLine();

            Student_Details user = new Student_Details(studentId, firstName, lastName,
                dateOfBirth, address);
            users.Add(user);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;

            studentId++;
        }


        public static void Adding_Tempary_User()
        {
            Student_Details user1 = new Student_Details(1001, "Malshi_1", "Gimnadhi_1", "29/7/1998", "abcd");
            users.Add(user1);
        
        }
        public static void Display_Modules()
        {
            Console.WriteLine("~~The Modules for the Third Semester~~");
            Console.WriteLine("**EE 3250 Programming  Project");
            Console.WriteLine("**EE 3251 GUI Prgramming");
            Console.WriteLine("**EE 3305 Signal and Systems");
            Console.WriteLine("**EE 3302 Data Structures and Algorithems");
            Console.WriteLine("**EE Measurement");
            Console.WriteLine("**EE 3301 Analog Electronics");


        }

        public static void Create_Module(int User_ID, int Module_Id)
        {

            foreach (var user in users)
            {

                if (user.ID == User_ID)
                {

                    switch (Module_Id)
                    {
                        case 3250:
                            Module_Details PP = new Module_Details(3250, "Programming  Project", 2);
                            user.Modules.Add(PP);
                            Console.WriteLine($"User is registed to {Module_Id}:{PP.Name}");
                            break;

                        case 3251:
                            Module_Details GUI = new Module_Details(3251, "GUI Prgramming", 2);
                            user.Modules.Add(GUI);
                            Console.WriteLine($"User  is registed to {Module_Id}:{GUI.Name}");
                            break;

                        case 3305:
                            Module_Details SAS = new Module_Details(3305, "Signal and Systems", 3);
                            user.Modules.Add(SAS);
                            Console.WriteLine($"User  is registed to {Module_Id}: {SAS.Name}");
                            break;

                        case 3302:
                            Module_Details DaA = new Module_Details(3302, "Data Structures and Algorithems", 3);
                            user.Modules.Add(DaA);
                            Console.WriteLine($"User  is registed to {Module_Id}:{DaA.Name}");
                            break;


                        case 3203:
                            Module_Details EM = new Module_Details(3203, "Electrical and Electronic Measurementst", 2);
                            user.Modules.Add(EM);
                            Console.WriteLine($"User  is registed to {Module_Id}: {EM.Name}");
                            break;

                        case 3301:
                            Module_Details AE = new Module_Details(3301, "Analog Electronics", 3);
                            Console.WriteLine($"User  is registed to {Module_Id}:{AE.Name}");
                            user.Modules.Add(AE);
                            break;


                        default:
                           
                            Console.WriteLine("Invalid Module Id..!!");

                            break;


                    }
                    break;
                }
            }

        }

        public static void Display_Modules(Student_Details user_module)
        {
            Console.SetCursorPosition(80, 0);
            int i = 1;

            Console.WriteLine("| ~~~The Registed Modules~~~");
            foreach (var mod in user_module.Modules)
            {
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"| ** {mod.Id} {mod.Name}");
                i = i + 1;
            }
            Console.SetCursorPosition(2, 0);


        }

        //Previouse Code for display users

        /*public static void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(50, 0);
            int i = 1;
            Console.WriteLine("ID\tFirst Name\t\tLast Name\tDate Of Birth\t\tAddress\t\t\t\t\t\t\t\tGPA");
            foreach (var user in users)
            {
                Console.SetCursorPosition(50, i);
                i = i + 1;
                Console.WriteLine($"{user.ID}\t{user.FirstName}\t\t\t{user.LastName}\t\t{user.DateOfBirth}\t{user.Address}\t\t\t\t\t\t\t\t\t\t{user.GPA_Value(user)}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;

        }*/



        //Newly added code with allignments.

        static int tableWidth = 100;

        //Display all users
        public static void Print()
        {
            
            PrintLine();
            PrintRow("ID", "First Name", "Last Name", "Date Of Birth", "Address", "GPA");
            PrintLine();
            int i = 1;
            foreach (var user in users)
            {
                i = i + 1;
                PrintRow($"{user.ID}",$"{user.FirstName}",$"{user.LastName}",$"{user.DateOfBirth}",$"{user.Address}",$"{user.GPA_Value(user)}");
            }
            PrintRow(" ", " ", " ", " ", " ", " ");
            PrintRow(" ", " ", " ", " ", " ", " ");
            PrintLine();
        }

        //Allignment with table stucture
       static void PrintLine()
       {
           Console.WriteLine(new string('-', tableWidth));
       }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        //Allign text inside the table.
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public static void PrintShort()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(75, 0);
            PrintLine();
            PrintRow("ID", "First Name", "Last Name");
            PrintLine();
            int i = 1;
            foreach (var user in users)
            {
                i = i + 1;
                PrintRow($"{user.ID}", $"{user.FirstName}", $"{user.LastName}");
            }
            PrintRow("", "", "", "", "", "");
            PrintRow("", "", "", "", "", "");
            PrintLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Delete_User(Student_Details user_del)
        {
            users.Remove(user_del);

        }

        public static void Display_One_User(Student_Details u)
        {

            //  Console.WriteLine("ID\tFirst Name\tLast Name\tDate Of Birth\t\tAddress");
            //Console.WriteLine($"{u.ID}\t{u.FirstName}\t\t{u.LastName}\t\t{u.DateOfBirth}\t\t{u.Address}");

            PrintLine();
            PrintRow("ID", "First Name", "Last Name", "Date Of Birth", "Address");
            PrintLine(); 
            PrintRow($"{u.ID}", $"{u.FirstName}", $"{u.LastName}", $"{u.DateOfBirth}", $"{u.Address}");
       
            PrintLine();

        }

    }
}