namespace CWTasks.TasksClasses
{
    class TaskThree
    {
        //Task 3:
        //The rgb function is incomplete. Complete it so that passing in RGB decimal values 
        //will result in a hexadecimal representation being returned.Valid decimal values for RGB are 0 - 255. 
        //Any values that fall out of that range must be rounded to the closest valid value.
        //Note: The answer should always be 6 characters long.
        private string _hexresult, _converted;

        public string ConvertRGB(int red, int green, int blue)
        {
            _converted = $"{ToHex(red)}{ToHex(green)}{ToHex(blue)}";
            return _converted;
        }

        private string ToHex(int value)
        {
            if (value < 0)
            { 
                _hexresult = "00";
            }
            else if (value > 255)
            {
                _hexresult = "FF";
            }
            else
            {
                _hexresult = value.ToString("X2");
            }
            return _hexresult;
        }
    }
}
