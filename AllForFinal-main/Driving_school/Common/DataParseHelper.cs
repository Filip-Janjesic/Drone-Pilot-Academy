using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Common
{
    public class DataParseHelper
    {
        public static int LoadNumberRange(string message, string error, int start, int end)
        {
            bool incorrectInput = true;
            int input = 0;
            do
            {                
                Console.Write(message);
                try
                {    
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        if (input >= start && input <= end)
                        {
                            incorrectInput = false;
                            break;
                        }
                    }                                        
                    Console.WriteLine(error);                                                                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            } while (incorrectInput);

            return input;
        }

        public static int LoadInteger(string message, string error)
        {
            bool incorrectInput = true;
            int input = 0;
            do
            {
                Console.Write(message);
                try
                {
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        if (input > 0)
                        {
                            incorrectInput = false;
                            break;
                        }
                    }                    
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            } while (incorrectInput);

            return input;
            
        }

        public static long LoadLong(string message, string error)
        {
            bool incorrectInput = true;
            long input = 0;
            do
            {
                Console.Write(message);
                try
                {
                    if (long.TryParse(Console.ReadLine(), out input))
                    {
                        if (input > 0)
                        {
                            incorrectInput = false;
                            break;
                        }
                    }
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            } while (incorrectInput);

            return input;

        }

        public static string LoadString(string message, string error)
        {
            bool incorrectInput = true;
            string? input = String.Empty;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && 
                    input.Trim().Length > 0)
                {
                    incorrectInput = false;
                    break;
                }
                Console.WriteLine(error);

            } while (incorrectInput);

            return input;
        }

        public static DateTime LoadDate(string message, string error)
        {
            bool incorrectInput = true;
            DateTime input = DateTime.MinValue;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    if (DateTime.TryParse(Console.ReadLine(), out input))
                    {
                        incorrectInput = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            } while (incorrectInput);

            return input;
                      
        }
        public static decimal LoadDecimal(string message, string error)
        {
            bool incorrectInput = false;
            decimal input = 0m;
            do
            {
                Console.Write(message);
                try
                {
                    if (decimal.TryParse(Console.ReadLine(), out input))
                    {
                        if (input > 0)
                        {
                            incorrectInput = false;
                            break;
                        }
                    }
                    
                    Console.WriteLine(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(error);
                }
            } while (incorrectInput);

            return input;
        }
    }


}
