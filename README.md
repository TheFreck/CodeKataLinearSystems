# CodeKataLinearSystems
https://www.codewars.com/kata/56b468a9b2230c6385000031

DESCRIPTION:
Your task is to solve N x N Systems of Linear Equations (e.g. Gauss Algorithm).
 
Here it's easy, you don't have to check errors or incorrect input values, every thing is ok and every given LS has exactly none or one solution (different from endless solutions for N x M Systems - see my harder kata). More about LS you can find here or perhaps is already known.
 
First of all two easy examples:

1*x1 + 2*x2 + 0*x3 = 7
0*x1 + 0*x2 + 3*x3 = 8
0*x1 + 5*x2 + 6*x3 = 9

SOLUTION=(9,8; -1,4; 2,66666666666667)
 
You can see exactly one solution which fulfills every equation (1*9,8 + 2*-1,4 + 0*2,66666666666667 =7 a.s.o.).
 
Second example:

1*x1 + 2*x2 + 0*x3 = 7
0*x1 + 0*x2 + 0*x3 = 8
0*x1 + 5*x2 + 6*x3 = 9

SOLUTION=NONE
 
There's no solution because the second equation isn't solvable.
 
So what info is missing?
 
You have to build a function "public string Solve (string input)" which takes the equations as an input string. "\r\n" (CRLF) separates the single equations, " " (SPACE) separates the numbers (like 3 or -1,5 only the coefficients not the xi's), each last number per line is the number behind the "=" (the equation result, see examples). The result of the function is the solution given as a string. All test examples will be syntactically correct, once again you don't need to take care of it.
 
So for the first example you have to call: Solve ("1 2 0 7\r\n0 0 3 8\r\n0 5 6 9"). The result of Solve is "SOLUTION=(9,8; -1,4; 2,66666666666667)", exactly in this form/syntax. Spaces in your result are allowed, but not necessary. Missing ";" or "(" throws an error. If there exists no solution you have to respond with "SOLUTION=NONE".
 
One last word to the tests:
The testfunction solves the given equations with your solution and accepts results which don't differ more than 1e-6 (precision) for each number - so no problem for you;-)!
