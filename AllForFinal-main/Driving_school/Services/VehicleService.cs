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
    public class VehicleService
    {
        public List<Vehicle> vehicles { get; }

        public VehicleService()
        {
            vehicles = new List<Vehicle>();

        }

        public void ShowMenu()
        {
            Console.WriteLine("  *   *   VEHICLES MENU  *   *   ");
            Console.WriteLine(" 1. SHOW VEHICLE LIST ");
            Console.WriteLine(" 2. ENTRY NEW VEHICLE ");
            Console.WriteLine(" 3. EDIT EXISTING VEHICLE DATA");
            Console.WriteLine(" 4. DELETE EXISTING VEHICLE ");
            Console.WriteLine(" 5. BACK TO MAIN MENU ");
            

            switch (DataParseHelper.LoadNumberRange(" SELECT WANTED OPTION\n",
               "OPTION HAS TO BE NUMBER FROM 1-5", 1, 5))
            {
                case 1:
                    ShowVehicles("show");
                    Console.ReadKey();
                    break;
                case 2:
                    EntryVehicle();

                    break;
                case 3:
                    EditVehicle();
                    break;
                case 4:
                    DeleteVehicle();
                    break;
                case 5:
                    var menu = new Menu();
                    menu.ShowMenu();
                    break;


            }

        }

        private void ShowVehicles(string action)
        {
            Console.Clear();

            if (vehicles.Any())
            {
                int V = 1;
                foreach (Vehicle vehicle in vehicles)
                {
                    WriteVehicleData(vehicle, V);
                    V++;

                } 


            }
            else
            {
                Console.WriteLine(String.Format("No vehicles to {0}.\nPress any key to return to the vehicle menu.", action));
                Console.ReadKey();
                ShowMenu();
            }

        }

        private void WriteVehicleData(Vehicle vehicle, int number)
        {
            Console.WriteLine(vehicle.Type);
            Console.WriteLine("{0}. {1}", number, vehicle);
        }

       




        private void DeleteVehicle()
        {
            ShowVehicles("delete");
            int input = DataParseHelper.LoadNumberRange(" Choose which vehicle you want to delete:\n",
                "Unknown vehicle selected.\nPlease try again.\n", 1, vehicles.Count);

            Console.WriteLine(String.Format("Are you sure you want to delete vehicle under the ID {0}? (Y/N)\n", input));
            do
            {
                var keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.Y)
                {
                    vehicles.RemoveAt(input - 1);
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

        private void EditVehicle()
        {
            ShowVehicles("edit");

            int input = DataParseHelper.LoadNumberRange(" Choose desired vehicle for editing:",
            "Error", 1, vehicles.Count);
            var vehicle = vehicles[input - 1];

            vehicle.ID = vehicles.Count + 1;
            vehicle.Type = DataParseHelper.LoadString(" ENTER VEHICLE TYPE(" + vehicle.Type + ")\n",
                    " ENTRY IS REQUIRED\n");
            vehicle.Brand = DataParseHelper.LoadString(" ENTER VEHICLE BRAND(" + vehicle.Brand + ")\n",
                " ENTRY IS REQUIRED\n");
            vehicle.Model = DataParseHelper.LoadString(" ENTER VEHICLE MODEL(" + vehicle.Model + ")\n",
                " ENTRY IS REQUIRED\n");
            vehicle.PurchaseDate = DataParseHelper.LoadDate(" ENTER VEHICLES PURCHASE DATE(" + vehicle.PurchaseDate + ")\n",
                " ENTRY IS REQUIRED\n");
            vehicle.RegistrationDate = DataParseHelper.LoadDate(" ENTRY VEHICLES REGISTRATION DATE(" + vehicle.RegistrationDate + ")\n",
                " ENTRY IS REQUIRED\n");
            vehicles.Add(vehicle);

            ActionSccuess("updated");
        }

       
        
           
        

        private void EntryVehicle()
        {
            var Vehicle = new Vehicle();
            Vehicle.ID = vehicles.Count + 1;
            Vehicle.Type = DataParseHelper.LoadString(" ENTER VEHICLE TYPE\n",
                    " ENTRY IS REQUIRED\n");
            Vehicle.Brand = DataParseHelper.LoadString(" ENTER VEHICLE BRAND\n",
                " ENTRY IS REQUIRED\n");
            Vehicle.Model = DataParseHelper.LoadString(" ENTER VEHICLE MODEL\n",
                " ENTRY IS REQUIRED\n");
            Vehicle.PurchaseDate = DataParseHelper.LoadDate(" ENTER VEHICLES PURCHASE DATE\n",
                " ENTRY IS REQUIRED\n");
            Vehicle.RegistrationDate = DataParseHelper.LoadDate(" ENTRY VEHICLES REGISTRATION DATE\n",
                " ENTRY IS REQUIRED\n");
            vehicles.Add(Vehicle);

            ActionSccuess("created");
        }

        private void ActionSccuess(string action)
        {
            Console.WriteLine(String.Format("Vehicle successfully {0}!\nPress any key to return to the vehicle menu.", action));
            Console.ReadKey();
            ShowMenu();
        }
    }

    



  

}





