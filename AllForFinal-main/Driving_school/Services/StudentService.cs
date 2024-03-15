using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using DrivingSchool.Common;
using DrivingSchool.Models;
using static System.Collections.Specialized.BitVector32;

namespace DrivingSchool.Services
{
    public class StudentService
    {
        public List<Student> students { get; }


        public StudentService()
        {
            students = new List<Student>();
        }

        public void ShowMenu()
        {
            Console.WriteLine("   *  *  STUDENTS MENU  *  *   ");
            Console.WriteLine(" 1. SHOW STUDENTS LIST ");
            Console.WriteLine(" 2. ENTRY NEW STUDENT ");
            Console.WriteLine(" 3. EDIT EXISTING STUDENT DATA");
            Console.WriteLine(" 4. DELETE EXISTING STUDENT ");
            Console.WriteLine(" 5. BACK TO MAIN MENU ");
          

            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION",
               "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 2:
                    Entrystudentsts();
                    break;
                case 1:
                    ShowStudents("show");
                    Console.ReadKey();
                    break;
                case 3:
                     EditStudent();
                    break;
                case 4:
                    Deletestudent();
                    break;
                case 5:
                    var menu= new Menu();
                    menu.ShowMenu();
                    break;


            }

        }

      

        private void WriteStudentData(Student student, int number)
        {
            Console.WriteLine(student.FirstName);
            Console.WriteLine("{0}. {1}", number, student);
        
    }

        private void Deletestudent()
        {

            ShowStudents("delete");
            int input = DataParseHelper.LoadNumberRange(" Choose which student you want to delete:\n",
                 "Unknown student selected.\nPlease try again.\n", 1, students.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete the student under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    students.RemoveAt(input - 1);
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

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Student successfully {0}!\nPress any key to return to the student menu.", action));
            Console.ReadKey();
            ShowMenu();
        }

        private void ShowStudents(string action)
        {
            Console.Clear();

            if (students.Any())
            {
                int STU = 1;
                foreach (Student student in students)
                {
                    WriteStudentData(student, STU);
                    STU++;
                }


            }
            else
            {
                Console.WriteLine(String.Format("No students to {0}.\nPress any key to return to the student menu.", action));
                Console.ReadKey();
                ShowMenu();
            }
        }

        private void EditStudent()
        {
            ShowStudents("edit");
            int input = DataParseHelper.LoadNumberRange("Choose desired student for editing:",
                "Error", 1, students.Count);
            var St = students[input - 1];

           
            St.FirstName = DataParseHelper.LoadString(" ENTER STUDENTS FIRST NAME: (" + St.FirstName + ")\n",
                " ENTRY IS REQUIRED ");
            St.LastName = DataParseHelper.LoadString(" ENTER STUDENTS LAST NAME: (" + St.LastName + ")\n",
                " ENTRY IS REQUIRED ");
            St.Address = DataParseHelper.LoadString(" ENTER STUDENTS ADDRESS: (" + St.LastName + ")\n",
                " ENTRY IS REQUIRED ");
            St.OIB = DataParseHelper.LoadInteger(" ENTER STUDENTS OIB: (" + St.OIB + ")\n",
                " ENTRY IS REQUIRED ");
            St.ContactNumber = DataParseHelper.LoadLong(" ENTER STUDENTS CONTACT NUMBER: (" + St.ContactNumber + ")\n",
                " ENTRY IS REQUIRED ");
            St.DateOfEnrolment = DataParseHelper.LoadDate(" ENTRY STUDENTS DATE OF ENROLMENT: (" + St.DateOfEnrolment + ")\n",
                 " ENTRY IS REQUIRED ");

        }

        



        private void Entrystudentsts()
        {
            var S = new Student();
          
            S.FirstName = DataParseHelper.LoadString(" ENTER STUDENTS FIRST NAME: ",
                " ENTRY IS REQUIRED ");
            S.LastName = DataParseHelper.LoadString(" ENTER STUDENTS LAST NAME: ",
                " ENTRY IS REQUIRED ");
            S.Address = DataParseHelper.LoadString(" ENTER STUDENTS ADDRESS: ",
                " ENTRY IS REQUIRED ");
            S.OIB = DataParseHelper.LoadInteger(" ENTER STUDENTS OIB: ",
                " ENTRY IS REQUIRED ");
            S.ContactNumber = DataParseHelper.LoadLong(" ENTER STUDENTS CONTACT NUMBER: ",
                " ENTRY IS REQUIRED ");
            S.DateOfEnrolment = DataParseHelper.LoadDate(" ENTRY STUDENTS DATE OF ENROLMENT: ",
                 " ENTRY IS REQUIRED ");
            students.Add(S);
        }



    }

}
