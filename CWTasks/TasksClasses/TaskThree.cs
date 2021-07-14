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

        public string ConvertRGB(int r, int g, int b)
        {
            return $"{ToHex(r)}{ToHex(g)}{ToHex(b)}";
        }

        private static string ToHex(int n)
        {
            var result = "";
            if (n < 0)
            { 
                result = 0.ToString("X2");
            }
            else if (n > 255) 
            {
                result = 255.ToString("X2");
            }
            else 
            {
                result = n.ToString("X2");
            }
            return result;
        }
    }
}
