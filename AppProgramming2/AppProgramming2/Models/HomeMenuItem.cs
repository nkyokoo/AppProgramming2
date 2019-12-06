using System;
using System.Collections.Generic;
using System.Text;

namespace AppProgramming2.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Weather,
        Logout,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
