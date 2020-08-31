using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SudokuWebsite.Services
{
    public class BoardSolver
    {
        public int[,] board = new int[9, 9] {
         { 0,6,0,4,2,0,1,8,5 },
         { 0,0,0,0,0,0,3,7,4 },
         { 4,1,0,3,0,8,0,0,0 },
         { 0,0,7,8,0,0,0,9,6 },
         { 3,0,6,7,0,0,0,0,0 },
         { 0,0,0,0,0,6,0,5,0 },
         { 0,7,0,9,0,0,5,0,0 },
         { 0,0,0,2,5,0,0,0,0 },
         { 0,4,0,0,1,3,8,0,0 },

            };


        public bool SolveBoard()
        {

            if (FindEmptySlot() == null)
            {          //no empty slots left
                Console.WriteLine("Board completed");
                return true;

            }


            //board not comleted lets go
            int[] slot = FindEmptySlot();

            for (int i = 1; i < board.GetLength(0) + 1; i++)
            {
                if (CheckIfValid(i, slot) == true)
                {
                    board[slot[0], slot[1]] = i;

                    if (SolveBoard() == true)
                    {
                        return true;
                    }
                    else
                    {
                        board[slot[0], slot[1]] = 0;
                    }
                }
            }
            return false;


        }


        public void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0) { Console.WriteLine("- - - - - - - - - - - - -"); }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0) { Console.Write(" | "); }
                    Console.Write(string.Format("{0},", board[i, j]));
                }
                Console.WriteLine();
            }

        }

        public int[] FindEmptySlot()
        {
            //holds row and column for found empty slot
            int[] coordinates = new int[2];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        //Console.WriteLine(i.ToString() + " " +  j.ToString());
                        return coordinates;
                    }
                }
            }
            return null;    //no empty slots left
        }

        bool CheckIfValid(int num, int[] pos)
        { // number to be checked, where we checking if valid



            //check row
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (num == board[pos[0], i] && pos[1] != i)
                {    //checking each slot on this row except the one we are trying to fill
                    return false;                                 //if there is the same number lets back it up and go back

                }
            }
            //check column
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (num == board[j, pos[1]] && pos[0] != j)
                {                            //checking each slot on this row except the one we are trying to fill
                    return false;                                //if there is the same number lets back it up and go back
                }
            }
            //check 3x3 box
            //breaking the board to 9 boxes with coordinates 0,0 - 0,1 - 0,2
            //   1,0 - 1,1 - 1,2
            //   2,0 - 2,1 - 2,2
            //by diving the slot coordinates by 3 and ignoring the remainders
            int box_x = pos[0] / 3;
            int box_y = pos[1] / 3;

            //remember you are starting from zero so the third box will be second how hard can it be to remember god damn it
            // by multiplying the divided coordinates with 3 we get the first x/y coordinate of the box we are in, and adding 3 to that we get the last x/y coordinate

            for (int i = box_x * 3; i < box_x * 3 + 3; i++)
            {

                for (int j = box_y * 3; j < box_y * 3 + 3; j++)
                {
                    if (num == board[i, j] && pos[0] == i && pos[1] == j)
                    {
                        return false;
                    }
                }
            }

            //we only get here if the number is valid to be added to the slot
            return true;

        }

    }


}
