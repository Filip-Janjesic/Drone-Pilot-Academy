using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Services;

namespace DrivingSchool.Common
{
    public class Menu
    {        
        public Menu()
        {

            InstructorService = new InstructorService();
            StudentService = new StudentService();
            VehicleService = new VehicleService();
            StatusService = new StatusService();
            CourseService = new CourseService();
            CategoryService = new CategoryService();
            WelcomeMessage();
            ShowMenu();
        }

        protected InstructorService InstructorService { get; private set; }
        protected StudentService StudentService { get; private set; }
        protected VehicleService VehicleService { get; private set; }
        protected StatusService StatusService { get; private set; }
        protected CourseService CourseService { get; private set; }
        protected CategoryService CategoryService { get; private set; }


        public void WelcomeMessage()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("   *   *   *   *   *   *   *");
            Console.WriteLine("** ** Driving School X ** **");
            Console.WriteLine("   *   *   *   *   *   *   *");
            Console.WriteLine("****************************");

        }
        public void ShowMenu()
        {            
            int choice;
            do
            {

                Console.Clear();
                WelcomeMessage();
                Console.WriteLine("   *    *     *    *    *   ");
                Console.WriteLine("   *    *    MAIN  *    *   ");
                Console.WriteLine("   *    *    MENU  *    *   ");
                Console.WriteLine("   *    *     *    *    *   ");

                Console.WriteLine("  1. INSTRUCTOR");
                Console.WriteLine("  2. STUDENTS");
                Console.WriteLine("  3. VEHICLES");
                Console.WriteLine("  4. COURSES");
                Console.WriteLine("  5. CATEGORIES");
                Console.WriteLine("  6. STATUSES");
                Console.WriteLine("  7. EXIT PROGRAM\n");

                choice = DataParseHelper.LoadNumberRange("SELECT WANTED OPTION\n",
                   "OPTION HAS TO BE NUMBER FROM 1-7\n", 1, 7);
                switch (choice)
                {
                    case 1:
                        InstructorService.ShowMenu();
                        break;
                    case 2:
                        StudentService.ShowMenu();
                        break;
                    case 3:
                        VehicleService.ShowMenu();
                        break;
                    case 4:
                        CourseService.ShowMenu();
                        break;
                    case 5:
                        CategoryService.ShowMenu();
                        break;
                    case 6:
                        StatusService.ShowMenu();
                        break;
                }
            } while (choice != 7);
            Console.WriteLine("  *  *  THANK YOU! GOODBYE :)  *  * ");
        }
    }




}
