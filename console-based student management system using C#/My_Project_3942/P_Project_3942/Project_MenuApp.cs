using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MenuApp
{
    public class Item_Menu
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }

        public Item_Menu(string title, bool isSelected)
        {
            Title = title;
            IsSelected = isSelected;
        }
    }
}
