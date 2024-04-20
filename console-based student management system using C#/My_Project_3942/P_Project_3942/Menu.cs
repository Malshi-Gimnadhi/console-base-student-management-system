using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using P_Project_3942;
using P_Project_3942.Folder;

namespace Project_MenuApp
{
    public class Menu
    {
        public int ColumnPosition { get; set; }
        public int RowPosition { get; set; }
        public int SelectedItem { get; set; }

        Select_User_Sub_Menu submenu = new Select_User_Sub_Menu();
        public List<Item_Menu> MenuItems { get; set; }
       


        public Menu()
        {
            ColumnPosition = 5;
            RowPosition = 3;
            SelectedItem = 0;
            MenuItems = new List<Item_Menu>
            {
                new Item_Menu("Add User",true),
                new Item_Menu("Select User",false),
                new Item_Menu("Delete User",false),
                new Item_Menu("Display All Users",false),
                new Item_Menu("Quit",false)
            };


        }


        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            List_Of_Data.Adding_Tempary_User();

            Console.Clear();
            bool running = true;
            bool display = true;

            while (running)
            {
                Console.SetCursorPosition(ColumnPosition, RowPosition);

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColumnPosition, RowPosition + i);
                    if (MenuItems[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        if (display == true) Console.Write(MenuItems[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        if (display == true) Console.Write(MenuItems[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem + 1) % MenuItems.Count;

                    MenuItems[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;

                    if (SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }


                if (key.Key == ConsoleKey.Enter)
                { 

                    Console.SetCursorPosition(20, 0);


                    bool stop = false;

                    while (!stop)
                    {




                        switch (MenuItems[SelectedItem].Title)
                        {
                            case "Add User":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                List_Of_Data.PrintShort();
                                Console.WriteLine("You choose Add Student_Details.  ");
                                List_Of_Data.Adding_New_User();
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("Press any key to insert once more.");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(2, 0);

                                break;

                            case "Select User":

                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;

                                List_Of_Data.PrintShort();

                                Console.WriteLine("You choose Select Student_Details");

                                Console.WriteLine("Enter the Uers Id");

                                int user_id = Convert.ToInt32(Console.ReadLine());
                                bool Checked_User_Id = false;
                                foreach (var user in List_Of_Data.users)
                                {
                                    if (user.ID == user_id)
                                    {
                                        Checked_User_Id = true;

                                        submenu.Display_Sub_Menu(user);
                                        break;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                if (Checked_User_Id == false) { Console.WriteLine("Incorrect user ID!"); }

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("To select once more, press any key");
                                Console.ForegroundColor = ConsoleColor.Black;
                              

                                break;
                                 
                            case "Delete User":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                List_Of_Data.PrintShort();
                                Console.WriteLine("You Choose Delete Student_Details");
                                Console.WriteLine("Enter the user Id ");
                                int d_id = Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid_d = false;
                                foreach (var user in List_Of_Data.users)
                                {
                                    if (user.ID == d_id)
                                    {
                                        List_Of_Data.Display_One_User(user);
                                        Console.WriteLine("Would you like this Student_Details to be deleted? Y/N");
                                        string r1 = Console.ReadLine();
                                        if ((r1 == "Y") || (r1 == "y"))
                                        {
                                            List_Of_Data.Delete_User(user);
                                            is_user_valid_d = true;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine($"Student_Details {user.ID} is Deleted Successfuly !");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        }

                                        break;
                                    }
                                }

                                if (is_user_valid_d == false) { Console.WriteLine("Incorrect user ID or Already deleted user \a"); }

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("To insert once more, press any key");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Display All Users":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("You Choose Display All Users");
                                List_Of_Data.Print();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);


                                break;
                              

                            case "Quit":
                                Console.Clear();
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(20, 15);

                                Console.WriteLine("You Choose Quit" +
                                    "  Exiting.....Please Wait.... \a");
                                running = false;
                                stop = true;

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Incorrect");
                                break;
                        }
                        if (stop != true)
                        {
                            Console.SetCursorPosition(2, 26);

                            Console.WriteLine("Press (B) to Back Main Menu");
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B") || (response == "b"))
                            {
                                stop = true;
                            }
                          
                            Console.SetCursorPosition(2, 0);
                        }

                    }

                }

            }
        }

    };
}







                
