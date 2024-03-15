using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Common;
using DrivingSchool.Models;

namespace DrivingSchool.Services
{
    public class InstructorService
    {
        public List<Instructor> instructors { get; set; }

        public InstructorService()
        {
            instructors = new List<Instructor>();
        }

        public void ShowMenu()
        {

            Console.Clear();
            Console.WriteLine("   *   *  INSTRUCTORS MENU  *   *  ");
            Console.WriteLine(" 1. SHOW INSTRUCTORS ");
            Console.WriteLine(" 2. CREATE NEW INSTRUCTOR ");
            Console.WriteLine(" 3. EDIT EXISTING INSTRUCTOR DATA");
            Console.WriteLine(" 4. DELETE EXISTING INSTRUCTOR ");
            Console.WriteLine(" 5. BACK TO MAIN MENU \n");                        


            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION\n",
                "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 1:
                    ShowInstructors("show");
                    Console.ReadKey();
                    break;
                case 2:
                    EntryNewInstructor();                    
                    break;
                case 3:
                    EditInstructor();
                    break;
                case 4:
                    DeleteInstructor();
                    break;
                case 5:
                    var menu = new Menu();
                    menu.ShowMenu();
                    break;
            }
        }

        private void DeleteInstructor()
        {
            ShowInstructors("delete");            
            int input = DataParseHelper.LoadNumberRange(" Choose which instructor you want to delete:\n",
                "Unknown instructor selected.\nPlease try again.\n", 1, instructors.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete the instructor under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    instructors.RemoveAt(input - 1);
                    ActionSccuess("deleted");
                    break;
                }
                else if (keyInput.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Delete process canceled.\nPress any key to return to instructor menu.");
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
        

        private void EditInstructor()
        {
            ShowInstructors("edit");
            
            int input = DataParseHelper.LoadNumberRange(" Choose desired instructor for editing:",
            "Error", 1, instructors.Count);
            var instructor = instructors[input - 1];
            
            instructor.FirstName = DataParseHelper.LoadString(" ENTER INSTRUCTORS FIRST NAME (" + instructor.FirstName + ")\n",
                    " ENTRY IS REQUIRED\n");
            instructor.LastName = DataParseHelper.LoadString("ENTER INSTRUCTORS LAST NAME (" + instructor.LastName + ")\n",
                " ENTRY IS REQUIRED\n ");
            instructor.DriverLicenceNumber = DataParseHelper.LoadInteger(" ENTER INSTRUCTORS DRIVERS LISCENCE NUMBER (" + instructor.DriverLicenceNumber + ")\n",
                " ENTRY IS REQUIRED\n");
            instructor.EMail = DataParseHelper.LoadString(" ENTRY INSTRUCTORS EMAIL (" + instructor.EMail + ")\n",
                " ENTRY IS REQUIRED\n");
            instructor.ContactNumber = DataParseHelper.LoadLong(" ENTRY INSTRUCTORS CONTACT NUMBER (" + instructor.ContactNumber + ")\n",
                " ENTRY IS REQUIRED\n");

            ActionSccuess("updated");
        }

        private void EntryNewInstructor()
        {
            var Instructor = new Instructor();
            Instructor.ID = instructors.Count + 1;
            Instructor.FirstName = DataParseHelper.LoadString(" ENTER INSTRUCTORS FIRST NAME\n",
                    " ENTRY IS REQUIRED\n");
            Instructor.LastName = DataParseHelper.LoadString(" ENTER INSTRUCTORS LAST NAME\n",
                " ENTRY IS REQUIRED\n");
            Instructor.DriverLicenceNumber = DataParseHelper.LoadInteger(" ENTER INSTRUCTORS DRIVERS LISCENCE NUMBER\n",
                " ENTRY IS REQUIRED\n");
            Instructor.EMail = DataParseHelper.LoadString(" ENTER INSTRUCTORS EMAIL\n",
                " ENTRY IS REQUIRED\n");
            Instructor.ContactNumber = DataParseHelper.LoadLong(" ENTRY INSTRUCTORS CONTACT NUMBER\n",
                " ENTRY IS REQUIRED\n");
            instructors.Add(Instructor);

            ActionSccuess("created");
        }


        private void ShowInstructors(string action)
        {
            Console.Clear();

            if (instructors.Any())
            {
               int I = 1;
                foreach (Instructor instructor in instructors)
                {
                    WriteInstructorData(instructor, I);
                    I++;
                    
                }

                
            }
            else
            {
                Console.WriteLine(String.Format("No instructors to {0}.\nPress any key to return to the instructor menu.", action));
                Console.ReadKey();
                ShowMenu();
            }
            
        }

        private void WriteInstructorData(Instructor instructor, int number)
        {
            Console.WriteLine(instructor.FirstName);
            Console.WriteLine("{0}. {1}", number, instructor);
        }

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Instructor successfully {0}!\nPress any key to return to the instructor menu.", action));
            Console.ReadKey();
            ShowMenu();
        }



    }




}
