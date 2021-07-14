using System;
using System.Text;
using CWTasks.Resources;

namespace CWTasks.TasksClasses
{
    public class TaskOne
    {
        //Task 1:
        //Usually when you buy something, you're asked whether your credit card number, 
        //phone number or answer to your most secret question is still correct. 
        //However, since someone could look over your shoulder, you don't want that shown on your screen. Instead, we mask it.
        //Your task is to write a function maskify, which changes all but the last four characters into '#'.
        
        private readonly string _zeroLengthException = MainResources.zeroLengthException;
        public string Maskify(string unmasked)
        {
            if (unmasked.Length == 0)
            {
                throw new Exception(_zeroLengthException);
            }
            else if (unmasked.Length > 4)
            {
                var res = new StringBuilder().Append('#', unmasked.Length - 4).Append(unmasked[^4..]);
                return res.ToString();
            }
            else
            {
                return unmasked;
            }
        }
    }
}
