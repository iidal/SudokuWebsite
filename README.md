# SudokuWebsite
I'll add to this file as I progress with the project


I started this project for a couple of reasons. First, to get back into web development for a little bit, in this case with .NET and Blazor. And second, to have something to do that lays more on the coding rather than designing a whole game.


If you want to check out some of the code, here are some shortcuts to the most important ones

[SudokuSolver.razor](Components/Sudokusolver.razor) - handles HTML and logic for the solver, apart for the solver algorithm itself

[SolverManager.cs](Controllers/SolverManager.cs) - the solver algorithm







**Backtracking**

Using backtracking was one of the main motives for this project since I had not really used any algorithms like it before. 
First, I researched how other people had approached this situation, and built the algorithm following the ones I felt were the cleanest approaches.
To but it simply, there are a few steps to the algorithm, which are repeated until the board is completed (if the input was valid).  Here is a short explanation which hopefully makes sense. I’ll add a flowchart, etc, at a later time.
1.	Find an empty slot on the board (marked as a zero)
2.	Put a number (1-9) to that slot and check if it is valid.

    a.	if yes, start again from step 1.
    
    b.	if not, change the slot to zero and try another number.
3.	If none of the numbers fit the slot, we change this slot back to zero and go to the previous one and start trying other numbers. Repeat this until
4.	The board is full, return true, or if the board cannot be completed return false

At first the algorithm worked fine, but once I started testing it problems appeared, particularly when I gave the algorithm only a few numbers that would not work (the same number in a row/column/box). The algorithm would keep looping trying to solve the board, sometimes seeming like an infinite loop, or give an incorrect solution. 
I could identify three different outcomes:
1.	Valid input, the algorithm works fine and returns true.
2.	Invalid input with a lot of numbers, the algorithm returns false as it should.
3.	Invalid input with only a few numbers, the algorithm keeps looping for what seems to be forever or sometimes returns true with incorrect solution.

So, I started looking at the other approaches more closely. Turns out they suffered with the same problem. Instead of starting from scratch, since the algorithm worked so well otherwise, I implemented a timer to stop the recursion after a certain time. A correct result will be achieved in less than a second, so letting the algorithm loop for longer is useless.
