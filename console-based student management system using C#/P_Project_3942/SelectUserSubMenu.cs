using P_Project_3942;
using P_Project_3942.Folder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_MenuApp
{
    public class Select_User_Sub_Menu
    {
        public int ColumnPosition2 { get; set; }
        public int RowPosition2 { get; set; }

        public List<Item_Menu> MenuItems2 { get; set; }
        public int SelectedItem2 { get; set; }

        

        public Select_User_Sub_Menu()
        {
            ColumnPosition2 = 15;
            RowPosition2 = 8;
            SelectedItem2 = 0;
            Console.ForegroundColor = ConsoleColor.Black;
            MenuItems2 = new List<Item_Menu>
            {   

                new Item_Menu("Modify User Details",true),
                new Item_Menu("Add Modules",false),
                new Item_Menu("Remove Modules",false),
                new Item_Menu("Add Grade",false),
                new Item_Menu("Delete User",false),
                new Item_Menu("Back",false)
            };
        }

        public void Display_Sub_Menu(Student_Details get_user)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.Clear();
            Console.CursorVisible = false;
            bool running2 = true;
            bool display2 = true;

            while (running2)
            {
                Console.SetCursorPosition(ColumnPosition2, RowPosition2);

                for (int i = 0; i < MenuItems2.Count; i++)
                {
                    Console.SetCursorPosition(ColumnPosition2, RowPosition2 + i);
                    if (MenuItems2[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = (SelectedItem2 + 1) % MenuItems2.Count;

                    MenuItems2[SelectedItem2].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = SelectedItem2 - 1;

                    if (SelectedItem2 < 0)
                    {
                        SelectedItem2 = MenuItems2.Count - 1;
                    }

                    MenuItems2[SelectedItem2].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(2, 0);



                    bool stop2 = false;

                    while (!stop2)
                    {



                        switch (MenuItems2[SelectedItem2].Title)
                        {
                            case "Modify User Details":
                                Console.Clear();
                                Console.WriteLine("Modify User Details");

                                Console.CursorVisible = true;


                                List_Of_Data.Display_One_User(get_user);
                                Console.WriteLine("1.Change First Name");
                                Console.WriteLine("2.Change Last Name");
                                Console.WriteLine("3.Change Date of Birth Name");
                                Console.WriteLine("4.Change Address");
                                string m1 = Console.ReadLine();

                                switch (m1)
                                {
                                    case "1":
                                        Console.WriteLine("Enter the First Name");
                                        get_user.FirstName = Console.ReadLine();
                                        List_Of_Data.Display_One_User(get_user);
                                        break;
                                    case "2":
                                        Console.WriteLine("Enter the Last Name");
                                        get_user.LastName = Console.ReadLine();
                                        List_Of_Data.Display_One_User(get_user);
                                        break;
                                    case "3":
                                        Console.WriteLine("Enter the Date of Birth Name");
                                        get_user.DateOfBirth = Console.ReadLine();
                                        List_Of_Data.Display_One_User(get_user);
                                        break;
                                    case "4":
                                        Console.WriteLine("Enter the Address Name");
                                        get_user.Address = Console.ReadLine();
                                        List_Of_Data.Display_One_User(get_user);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Index..!"!);
                                        break;
                                }


                                Console.CursorVisible = false;
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;



                            case "Add Modules":
                                Console.Clear();
                                List_Of_Data.Display_Modules(get_user);
                                Console.WriteLine("You selected Add Modules");
                                List_Of_Data.Display_Modules();
                                List_Of_Data.Display_One_User(get_user);

                                Console.WriteLine($"\nEnter the module Id to add a new module to user {get_user.FirstName}:");
                                int idmod = Convert.ToInt32(Console.ReadLine());
                                bool isadded = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod)
                                    {
                                        Console.WriteLine("module is already Added");
                                        isadded = true;
                                        break;
                                    }


                                }
                                if (isadded == false) List_Of_Data.Create_Module(get_user.ID, idmod);
                                List_Of_Data.Display_Modules(get_user);

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;



                            case "Delete Student_Details":
                                Console.Clear();
                                Console.WriteLine("You Selected Delete Student_Details");
                                List_Of_Data.Display_One_User(get_user);
                                Console.WriteLine("\nDo you want to delete this Student_Details y/n");
                                string r1 = Console.ReadLine();
                                if ((r1 == "Y") || (r1 == "y"))
                                {
                                    List_Of_Data.Delete_User(get_user);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"Student_Details {get_user.FirstName} is Removed Successfuly !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                running2 = false;
                                stop2 = true;
                                break;


                            case "Remove Modules":
                                Console.Clear();
                                List_Of_Data.Display_Modules();
                                List_Of_Data.Display_Modules(get_user);
                                Console.WriteLine("You Selected Remove Modules");
                                List_Of_Data.Display_One_User(get_user);
                                Console.WriteLine($"\nEnter the Module Id to delete the module from user:{get_user.FirstName}");
                                int idmod_r = Convert.ToInt32(Console.ReadLine());
                                bool isdeleted = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod_r)
                                    {
                                        get_user.Modules.Remove(mod);
                                        isdeleted = true;
                                        break;
                                    }


                                }
                                Console.Clear();

                                if (isdeleted == false) 
                                    Console.WriteLine("Module is already deleted or Invalid Module Id");
                                List_Of_Data.Display_One_User(get_user);
                                List_Of_Data.Display_Modules(get_user);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to Insert Again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;


                            case "Add Grade":
                                Console.Clear();
                                List_Of_Data.Display_Modules(get_user);
                                Console.WriteLine("You Selected Add Grades Section");
                                List_Of_Data.Display_One_User(get_user);
                                Console.WriteLine($"\nEnter the Module Id to add Module Grade for the user: {get_user.FirstName}");
                                int get_mod_id = Convert.ToInt32(Console.ReadLine());
                                bool is_mod_registered = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == get_mod_id)
                                    {
                                        Console.WriteLine("Enter the Grade\n");
                                        Console.WriteLine("A.A\nB.B\nC.C\nE.E");
                                        string grade = Console.ReadLine().ToLower();
                                        is_mod_registered = true;
                                        switch (grade)
                                        {
                                            case "a":
                                                mod.Grade_Point = 4;
                                                Console.WriteLine("Grade 'A' added");
                                                break;
                                            case "b":
                                                mod.Grade_Point = 3;
                                                Console.WriteLine("Grade 'B' added");
                                                break;
                                            case "c":
                                                mod.Grade_Point = 2.5;
                                                Console.WriteLine("Grade 'C' added");
                                                break;
                                            case "E":
                                                mod.Grade_Point = 0;
                                                Console.WriteLine("Grade 'E' added");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid Grade..!!");
                                                break;
                                        }


                                        break;
                                    }
                                }
                                if (is_mod_registered == false) { Console.WriteLine("Invalid Index..!!"); }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                            case "Back":
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();


                                running2 = false;
                                stop2 = true;

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid..!!");
                                break;
                        }
                        if (stop2 != true)
                        {
                            Console.SetCursorPosition(2, 25);
                            Console.WriteLine("Press (B) to Back");

                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B") || (response == "b"))
                            {
                                stop2 = true;

                            }
                            Console.SetCursorPosition(2, 0);
                        }




                    }
                }
            }
        }
    };
}
