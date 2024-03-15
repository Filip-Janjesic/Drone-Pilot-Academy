using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Common;
using DrivingSchool.Models;


namespace DrivingSchool.Services
{
    public class CourseService
    {
        public List<Course> courses { get; set; }
        public CourseService()

        {
            courses = new List<Course>();
        }

        public void ShowMenu()
        {
            Console.WriteLine("  *   *   COURSE MENU  *   *   ");
            Console.WriteLine(" 1. SHOW COURSE LIST ");
            Console.WriteLine(" 2. ENTRY NEW COURSE ");
            Console.WriteLine(" 3. EDIT START DATE");
            Console.WriteLine(" 4. DELETE EXISTING COURSE ");
            Console.WriteLine(" 5. BACK TO MAIN MENU ");


            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION",
               "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 2:
                    EntryCourse();
                    break;
                case 1:
                    ShowCourse("show");
                    Console.ReadKey();
                    break;
                case 3:
                    EditStartDate();
                    break;
                case 4:
                    DeleteCourse();
                    break;
                case 5:
                    var menu = new Menu();
                    menu.ShowMenu();
                    break;


            }

        }

        private void ShowCourse(string action)
        {
            Console.Clear();

            if (courses.Any())
            {
                int COU = 1;
                foreach (Course course in courses)
                {
                    WriteCourseData(course, COU);
                    COU++;
                }


            }
            else
            {
                Console.WriteLine(String.Format("No courses to {0}.\nPress any key to return to the course menu.", action));
                Console.ReadKey();
                ShowMenu();
            }
        }

        private void WriteCourseData(Course course, int number)
        {
            Console.WriteLine(course.StartDate);
            Console.WriteLine("{0}. {1}", number, course);
        }

        private void EditStartDate()
        {
            ShowCourse("edit");
            int input = DataParseHelper.LoadNumberRange(" Choose desired course for editing:",
            "Error", 1, courses.Count);
            var course = courses[input - 1];

            course.StartDate = DataParseHelper.LoadDate(" ENTER COURSE START DATE (" + course.StartDate + ")\n",
                    " ENTRY IS REQUIRED\n");
        }

        private void DeleteCourse()
        {
            ShowCourse("delete");
            int input = DataParseHelper.LoadNumberRange(" Choose which course you want to delete:\n",
                "Unknown course selected.\nPlease try again.\n", 1, courses.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete course under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    courses.RemoveAt(input - 1);
                    ActionSccuess("deleted");
                    break;
                }
                else if (keyInput.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Delete process canceled.\nPress any key to return to course menu.");
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

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Instructor successfully {0}!\nPress any key to return to the instructor menu.", action));
            Console.ReadKey();
            ShowMenu();
        }

        private void EntryCourse()
        {
            var course = new Course();
            course.ID = courses.Count + 1;

            course.StartDate = DataParseHelper.LoadDate(" ENTER COURSE START DATE (" + course.StartDate + ")\n",
                    " ENTRY IS REQUIRED\n");
            ActionSccuess("created");

        }

       
    }

}


