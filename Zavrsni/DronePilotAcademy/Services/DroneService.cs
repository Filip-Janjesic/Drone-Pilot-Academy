using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using DronePilotAcademy.Common;
using DronePilotAcademy.Models;
using static System.Collections.Specialized.BitVector32;

namespace DronePilotAcademy.Services
{
    public class DroneService
    {
        public List<Drone> drones { get; }

        public DroneService()
        {
            drones = new List<Drone>();

        }

        public void ShowMenu()
        {
            Console.WriteLine("  *   *   DRONE MENU  *   *   ");
            Console.WriteLine(" 1. SHOW DRONE LIST ");
            Console.WriteLine(" 2. ENTRY NEW DRONE ");
            Console.WriteLine(" 3. EDIT EXISTING DRONE DATA");
            Console.WriteLine(" 4. DELETE EXISTING DRONE ");
            Console.WriteLine(" 5. BACK TO MAIN MENU ");
            

            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION\n",
               "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 1:
                    ShowDrones("show");
                    Console.ReadKey();
                    break;
                case 2:
                    EntryDrone();

                    break;
                case 3:
                    EditDrone();
                    break;
                case 4:
                    DeleteDrone();
                    break;
                case 5:
                    var menu = new Menu();
                    menu.ShowMenu();
                    break;


            }

        }

        private void ShowDrones(string action)
        {
            Console.Clear();

            if (drones.Any())
            {
                int D = 1;
                foreach (Drone drone in drones)
                {
                    WriteDroneData(drone, D);
                    D++;

                } 


            }
            else
            {
                Console.WriteLine(String.Format("No drones to {0}.\nPress any key to return to the drone menu.", action));
                Console.ReadKey();
                ShowMenu();
            }

        }

        private void WriteDRONEData(Drone drone, int number)
        {
            Console.WriteLine(drone.Type);
            Console.WriteLine("{0}. {1}", number, drone);
        }

       




        private void DeleteDrone()
        {
            ShowDRONEs("delete");
            int input = DataParseHelper.LoadNumberRange(" Choose which DRONE you want to delete:\n",
                "Unknown DRONE selected.\nPlease try again.\n", 1, DRONEs.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete DRONE under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    drones.RemoveAt(input - 1);
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

        private void EditDrone()
        {
            ShowDrones("edit");

            int input = DataParseHelper.LoadNumberRange(" Choose desired drone for editing:",
            "Error", 1, drones.Count);
            var drone = drones[input - 1];

            drone.ID = drones.Count + 1;
            drone.Type = DataParseHelper.LoadString(" ENTER DRONE TYPE(" + drone.Type + ")\n",
                    " ENTRY IS REQUIRED\n");
            drone.Brand = DataParseHelper.LoadString(" ENTER DRONE BRAND(" + drone.Brand + ")\n",
                " ENTRY IS REQUIRED\n");
            drone.Model = DataParseHelper.LoadString(" ENTER DRONE MODEL(" + drone.Model + ")\n",
                " ENTRY IS REQUIRED\n");
            drone.PurchaseDate = DataParseHelper.LoadDate(" ENTER DRONES PURCHASE DATE(" + drone.PurchaseDate + ")\n",
                " ENTRY IS REQUIRED\n");
            drone.RegistrationDate = DataParseHelper.LoadDate(" ENTRY DRONES REGISTRATION DATE(" + drone.RegistrationDate + ")\n",
                " ENTRY IS REQUIRED\n");
            drones.Add(drone);

            ActionSccuess("updated");
        }

       
        
           
        

        private void EntryDrone()
        {
            var Drone = new Drone();
            Drone.ID = drones.Count + 1;
            Drone.Type = DataParseHelper.LoadString(" ENTER DRONE TYPE\n",
                    " ENTRY IS REQUIRED\n");
            Drone.Brand = DataParseHelper.LoadString(" ENTER DRONE BRAND\n",
                " ENTRY IS REQUIRED\n");
            Drone.Model = DataParseHelper.LoadString(" ENTER DRONE MODEL\n",
                " ENTRY IS REQUIRED\n");
            Drone.PurchaseDate = DataParseHelper.LoadDate(" ENTER DRONES PURCHASE DATE\n",
                " ENTRY IS REQUIRED\n");
            Drone.RegistrationDate = DataParseHelper.LoadDate(" ENTRY DRONES REGISTRATION DATE\n",
                " ENTRY IS REQUIRED\n");
            drones.Add(Drone);

            ActionSccuess("created");
        }

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Drone successfully {0}!\nPress any key to return to the drone menu.", action));
            Console.ReadKey();
            ShowMenu();
        }
    }

    



  

}





