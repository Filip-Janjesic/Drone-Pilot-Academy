using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Common;
using DrivingSchool.Models;
using static System.Collections.Specialized.BitVector32;

namespace DrivingSchool.Services
{
    public class CategoryService
    {
        public List<Category> categories { get; set; }

        public CategoryService()
        {
            categories = new List<Category>();
        }

        public void ShowMenu()
        {
            Console.WriteLine("   *   *  CATEGORY MENU  *   *  ");
            Console.WriteLine(" 1. SHOW CATEGORIES ");
            Console.WriteLine(" 2. ENTRY NEW CATEGORY ");
            Console.WriteLine(" 3. EDIT EXISTING CATEGORY DATA");
            Console.WriteLine(" 4. DELETE EXISTING CATEGORY ");
            Console.WriteLine(" 5. BACK TO MAIN MENU ");
            
           

            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION",
               "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 1:
                    ShowCategories("show");
                    Console.ReadKey();
                    break;
                case 2:
                    EntryNewCategory();
                    break;
                case 3:
                    EditCategory();
                    break;
                case 4:
                    DeleteCategory();
                    break;
                case 5:
                    var menu = new Menu();
                    menu.ShowMenu();
                    break;



            }
        }

        private void DeleteCategory()
        {
            ShowCategories("delete");
            int input = DataParseHelper.LoadNumberRange(" Choose which category you want to delete:\n",
                "Unknown category selected.\nPlease try again.\n", 1, categories.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete this category under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    categories.RemoveAt(input - 1);
                    ActionSccuess("deleted");
                    break;
                }
                else if (keyInput.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Delete process canceled.\nPress any key to return to vehicle menu.");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Unkown key command. Please press Y or N.");
                }
            } while (true);
        }

        private void EditCategory()
        {
            ShowCategories("edit");


            {

                int input = DataParseHelper.LoadNumberRange(" Choose desired category for editing:",
               "Error", 1, categories.Count);
                var CAT = categories[input - 1];


                CAT.ID = DataParseHelper.LoadInteger(" ENTRY CATEGORY ID NUMBER (" + CAT.ID + ")",
                       " ENTRY HAS TO BE A POSITIVE WHOLE NUMBER ");
                CAT.Name = DataParseHelper.LoadString(" ENTER CATEGORY NAME (" + CAT.Name + ")",
                        " ENTRY IS REQUIRED ");
                CAT.Price = DataParseHelper.LoadDecimal("ENTER INSTRUCTORS LAST NAME (" + CAT.Price + ")",
                    " ENTRY IS REQUIRED ");
                CAT.NumberOfTRLectures = DataParseHelper.LoadInteger(" ENTER NUMBER OF TRL (" + CAT.NumberOfTRLectures + ")",
                    " ENTRY IS REQUIRED ");
                CAT.NumberOfDrivingLectures = DataParseHelper.LoadInteger(" ENTRY DL number (" + CAT.NumberOfDrivingLectures + ")",
                    " ENTRY IS REQUIRED ");


                ActionSccuess("updated");

            }
        }

        private void EntryNewCategory()
        {
            var Category = new Category();
            Category.ID = categories.Count + 1;
            Category.Name = DataParseHelper.LoadString(" ENTER STUDENTS FIRST NAME\n ",
                " ENTRY IS REQUIRED ");
            Category.Price = DataParseHelper.LoadDecimal(" ENTER STUDENTS LAST NAME\n ",
                " ENTRY IS REQUIRED ");
            Category.NumberOfTRLectures = DataParseHelper.LoadInteger(" ENTER STUDENTS ADDRESS\n ",
                " ENTRY IS REQUIRED ");
            Category.NumberOfDrivingLectures = DataParseHelper.LoadInteger(" ENTER STUDENTS OIB\n ",
                " ENTRY IS REQUIRED ");

            ActionSccuess("created");
        }

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Category successfully {0}!\nPress any key to return to the category menu.", action));
            Console.ReadKey();
            ShowMenu();
        }

        private void ShowCategories(string action)
        {
            Console.Clear();

            if (categories.Any())
            {
                int Catego = 1;
                foreach (Category category in categories)
                {
                    WriteCategoryData(category, Catego);
                    Catego++;

                }


            }
            else
            {
                Console.WriteLine(String.Format("No categories to {0}.\nPress any key to return to the category menu.", action));
                Console.ReadKey();
                ShowMenu();
            }

        }

        private void WriteCategoryData(Category category, int number)
        {
            Console.WriteLine(category.Name);
            Console.WriteLine("{0}. {1}", number, category);
        }
    }

}





