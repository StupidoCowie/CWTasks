using System.Text;

namespace CWTasks.TasksClasses
{
    public class TaskOne
    {
        /*Task 1:
         * Usually when you buy something, you're asked whether your credit card number, 
         * phone number or answer to your most secret question is still correct. 
         * However, since someone could look over your shoulder, you don't want that shown on your screen. Instead, we mask it.
         * 
         * Your task is to write a function maskify, which changes all but the last four characters into '#'.*/
        public string Maskify(string unmasked)
        {
            if (unmasked.Length > 4)
            {
                var res = new StringBuilder();
                res.Append(new string('#', unmasked.Length - 4));
                return res.Append(unmasked[^4..]).ToString();
            }
            else
            {
                return unmasked;
            }
        }
    }
}
