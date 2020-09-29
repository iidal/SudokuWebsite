using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Diagnostics;

namespace SudokuWebsite.Services
{
    public class BoardSolver
    {
        public int[,] board = new int[9, 9] {
             { 5,6,8,0,0,0,0,0,0 },
             { 3,0,0,0,0,0,0,1,5 },
             { 0,9,0,0,0,0,6,0,3 },
             { 0,8,0,0,0,0,1,3,0 },
             { 0,0,9,0,3,0,0,0,4 },
             { 7,3,0,0,6,0,5,0,0 },
             { 4,0,3,8,9,0,0,0,0 },
             { 0,2,0,0,0,5,0,7,0 },
             { 0,0,1,0,0,6,0,4,9 },

            };

        BoardChecker BC = new BoardChecker();
        Stopwatch sw;

        public bool StartSolving() {
            TimerCounting(); //start timer
            return SolveBoard();

        }

        void TimerCounting() {
            sw = new Stopwatch();
            sw.Start();
        }
        //recursively going through the board tryig to add values to it
        public bool SolveBoard()
        {
 
                if (FindEmptySlot() == null)
                {          //no empty slots left we are done
                    Console.WriteLine("Board completed");
                    PrintBoard();


               if (!BC.CheckFullBoard(board)) {    //check if the full board is fine. mostly this needs to be checked in case the user inputs a full board, which the original algorithm does not check
                   return false;
                }

                //if the full board is fine:
                    return true;

                }


                if (sw.ElapsedMilliseconds > 3000)  //keep checking the timer, we dont wanna get caught in an kinda infinite loop
                {
                    sw.Stop();
                    return false; //back it up boys nothing to see here go back  

                }


            //board not comlpeted lets go
            int[] slot = FindEmptySlot();   //find an empty slot

                for (int i = 1; i < board.GetLength(0) + 1; i++)
                {


                    if (CheckIfValid(i, slot) == true)  //check if a number is valid for the slot and the board
                    {
                        board[slot[0], slot[1]] = i;    //if yes, add it to the board

                        if (SolveBoard() == true)   //try to solve the board, try adding some number to the next empty slot
                        {
                            return true;    //keep doing that
                        }
                        else
                        {
                            board[slot[0], slot[1]] = 0;    //oops the value wasnt valid, but lets continue trying with a different one
                            
                         
                        }
                    }
                }
                //Console.WriteLine(sw.ElapsedMilliseconds);

                return false; //if none of the numbers 1-9 are not be valid for a slot, we will backtrack



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
                        return coordinates;
                    }
                }
            }
            return null;    //no empty slots left
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
