using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTasks.TasksClasses
{
    class TaskThree
    {
        //Task 3:
        //The rgb function is incomplete. Complete it so that passing in RGB decimal values 
        //will result in a hexadecimal representation being returned.Valid decimal values for RGB are 0 - 255. 
        //Any values that fall out of that range must be rounded to the closest valid value.
        //Note: The answer should always be 6 characters long.

        public string ConvertRGB(int red, int green, int blue)
        {
            return $"{ToHex(red)}{ToHex(green)}{ToHex(blue)}";
        }

        private static string ToHex(int value)
        {
            var result = "";
            if (value < 0)
            { 
                result = "00";
            }
            else if (value > 255) 
            {
                result = "FF";
            }
            else 
            {
                result = value.ToString("X2");
            }
            return result;
        }
    }
}
