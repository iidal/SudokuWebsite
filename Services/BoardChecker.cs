using System;
using System.Collections.Generic;
using System.Linq;


using Microsoft.AspNetCore.Hosting;



namespace SudokuWebsite.Services
{
    public class BoardChecker
    {
        //BoardSolver BS = new BoardSolver();
        public int[,] board = new int[9, 9] {
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },
             { 0,0,0,0,0,0,0,0,0 },

            }; 

        public bool CheckFullBoard(int[,] boardToCheck) {

            board = (int[,])boardToCheck.Clone();

            for (int i = 0; i<board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    int[] slot = new int[] { i, j };

                    if (!CheckIfValid(board[i, j], slot)) {
                        return false;
                    }
                }
            }
            return true;
        
        }

        public bool CheckIfValid(int num, int[] pos)
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


            int box_x = pos[1] / 3;
            int box_y = pos[0] / 3;     //x value is assigned to y and vice versa because x is rows and is columns, and we are going from left to right then down we need the column value first


            //remember you are starting from zero so the third box will be second how hard can it be to remember god damn it 
            // by multiplying the divided coordinates with 3 we get the first x/y coordinate of the box we are in, and adding 3 to that we get the last x/y coordinate

            for (int i = box_y * 3; i < box_y * 3 + 3; i++)
            {

                for (int j = box_x * 3; j < box_x * 3 + 3; j++)
                {

                    if (num == board[i, j] && pos[0] != i && pos[1] != j)
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
