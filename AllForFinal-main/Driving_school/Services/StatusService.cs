using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Common;
using DrivingSchool.Models;

namespace DrivingSchool.Services
{
    public class StatusService
    {
        private static List<Status> statuses = new List<Status>()
        {
            new Status() {ID = 1, Description = "ENROLLED"},
            new Status() {ID = 2, Description = "LISTENING TR"},
            new Status() {ID = 3, Description = "WAITING ON TR EXAM"},
            new Status() {ID = 4, Description = "LISTENING FA"},
            new Status() {ID = 5, Description = "WAITING FA EXAM"},
            new Status() {ID = 6, Description = "WAITING DL"},
            new Status() {ID = 7, Description = "DRIVING LESSONS"},
            new Status() {ID = 8, Description = "WAITING DL EXAM"},
            new Status() {ID = 9, Description = "WAITING HAK"},
            new Status() {ID = 10, Description = "DISMISSED"}
        };        

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(" STATUS MENU ");
            Console.WriteLine(" 1. SHOW STATUS LIST ");
            Console.WriteLine(" 2. BACK TO MAIN MENU \n");            
            
            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION\n",
            "OPTION HAS TO BE NUMBER FROM 1-2\n", 1, 2))
            {
                case 1:
                    ShowStatus();  
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine(" DONE WORKING WITH STATUS MENU");
                    var menu = new Menu();
                    menu.ShowMenu();                    
                    break;
                default:
                    break;
            }                  
        }

        private void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("Statuses: ");
            int i = 1;
            foreach (var status in statuses)
            {
                Console.WriteLine(String.Format("{0}. {1}", i, status.Description));
                i++;
            }

            Console.WriteLine("Press any key to go back to statuses menu");
            Console.ReadKey();
            ShowMenu();
        }

    }
}


