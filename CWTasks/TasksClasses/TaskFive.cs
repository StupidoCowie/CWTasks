using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTasks.TasksClasses
{
    class TaskFive
    {
        //Task 5:
        //Write a function  that accepts a 2D array representing a Sudoku board, and returns true if it is a valid solution, or false otherwise.
        //The cells of the sudoku board may also contain 0's, which will represent empty cells. 
        //Boards containing one or more zeroes are considered to be invalid solutions.
        //The board is always 9 cells by 9 cells, and every cell only contains integers from 0 to 9.

        public bool ValidateSolution(int[][] board)
        {
            if (board.Count(x => x.Length == 9) != 9)
            {
                return false;
            }
            foreach (int[] v in board)
            {
                foreach (int b in v)
                {
                    if(v.Count(x => x == b) > 1 || b == 0)
                    {
                        return false;
                    }
                }
            }

            var innerIndex = 0;
            var subMatrix = new List<int>();
            for (var i = 0; i < 9; i++)
            {
                for (var j = innerIndex; j < innerIndex + 3; j++)
                {
                    subMatrix.Add(board[i][j]);
                }
                if ((i + 1) % 3 == 0)
                {
                    if (subMatrix.Distinct().ToArray().Length != 9)
                    {
                        return false;
                    }
                    else
                    {
                        i -= 3;
                        innerIndex += 3;
                        subMatrix.Clear();
                    }
                }
                if (innerIndex == 9)
                {
                    i += 3;
                    innerIndex = 0;
                }
            }
            return true;
        }
    }
}
