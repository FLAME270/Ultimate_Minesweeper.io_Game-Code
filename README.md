<h1 align="center">Hi 👋, I'm Tyler Wiggins, I am a full stack developer with a Bachelor of Science in Software Development.</h1>


<h3 align="left">Project Description:</h3>
<p>Life is all about learning new things, to challenge myself, I decided to program a modern-looking Minesweeper game using the C# ASP.Net core framework. In the process, I learned how to make forms and program the backend functionality for the user interface. It would be very inconvenient to program every cell, so I used arrays to generate every row and column, then used a random number generator to generate the mines. The most complicated part of my minesweeper program was setting an algorithm that used recursion to detect all of the empty spaces that is not touching a mine and reveal the surrounding numbers.
<br>
<br>




<h3 align="left">How to Install my Minesweeper Game:</h3>
<p>Go to https://visualstudio.microsoft.com/ and install the community edition of Visual Studio.
 
  ![image](https://user-images.githubusercontent.com/46502423/166826135-779c4b61-48c5-4622-a8c9-14cbc619417c.png)


<p>Once you install the Visual Studio installer, the community edition of Visual Studios will start installing.
 
  ![image](https://user-images.githubusercontent.com/46502423/166827278-68a7ff57-745a-475e-ac88-26ceb633f328.png)

  <p>Once Visual Studios is installed, launch it to ensure that it was installed correctly.</p>
 
  ![image](https://user-images.githubusercontent.com/46502423/166835544-d2249a60-7940-4ef5-b752-fc37410f0669.png)

<p>Next step is to clone the Minesweeper game from GitHub. Click the green "Code🔻" button and choose the "Open with Visual Studios" option.
 
![image](https://user-images.githubusercontent.com/46502423/166841855-1de2a068-da6c-4dcb-83c2-d8216970db72.png)
 
  <p>If this message pops up, simply click the "Open Microsoft Visual Studio Web Protocol Handler Sector" button. </p>

![image](https://user-images.githubusercontent.com/46502423/166842086-8bfe99a6-2286-47f7-bddd-d3846e06baf5.png)

<p>Next choose a folder location to clone the Minesweeper game too, then click the "Clone" button.</p>
 
  ![image](https://user-images.githubusercontent.com/46502423/166842705-22a3afc1-0388-42b6-a01f-85267c87522f.png)

<p>Now that the minesweeper is cloned in Visual Studios, simply click the "Start" button. The program should start and pop up in a new window.</p>

![image](https://user-images.githubusercontent.com/46502423/166844065-87bb4bce-f626-4a6a-b071-1a36a3b87408.png)

<p>Choose a difficulty and click the "Play Game" button, then the game board will pop up.</p>

![image](https://user-images.githubusercontent.com/46502423/166844534-f3c69662-4d02-4049-b6e1-78088104b05a.png)

![image](https://user-images.githubusercontent.com/46502423/166844621-dd59983e-7309-4b36-83d7-527c9e2b333e.png)

<p>Click a cell to reveal open areas, if you think the cell contains a mine, right-click to flag it. </p>

![image](https://user-images.githubusercontent.com/46502423/166845614-7364198a-e0f2-4111-b19c-398aae3baf45.png)

<p>If you click on a mine, you have the option to play again or exit the game (close the entire program).
 
  ![image](https://user-images.githubusercontent.com/46502423/166846053-a0fc9828-7f89-447f-bfa8-65f7e5ab952e.png)

  <p>Once all the squares are cleared and the mines are flagged, the game will tell you how long it took to clear the game board. If you got a new high score, you will be asked to enter your initials and be added to the leaderboard. </p>
 
  ![image](https://user-images.githubusercontent.com/46502423/166847296-a772e78e-69b6-4dbb-bfc0-6bf13247e8bb.png)

![image](https://user-images.githubusercontent.com/46502423/166847302-052c4549-ba2c-44f6-95c7-007420a2ba44.png)

<p>Thanks for playing my Minesweeper game. Have Fun 🎉 and good luck with beating the difficult game mode 😉</p>
<br>
<p>Note: If you need instructions on how to play Minesweeper, check out the instructions below ⬇️

<br>
<br>


<h3 align="left">How to Play Minesweeper:</h3>
Minesweeper is a game about learning patterns and using the process of elimination.

Your first square is completely random, as there is no info to go on, though I suggest picking one near the middle. The edges give you less info to work with.
Most games will auto-mine if a blank square is revealed, but the principle is this: if you find a square with no numbers, all eight adjacent squares are safe so mine. Do so until you have a whole outer wall of numbered squares. If you get a numbered square on your first try, start over.
Ideally, you'd have a sprawling concave shape to work with. If you have a 9x9 square start again from the beginning. This is where your pattern recognition will have to kick in. Look at this example:

The first thing to recognize is that if there is an inside corner, there is a mine. Second, a 1,2,1 pattern always has the mines on the 1’s. Put flags down where you think the mines are.
Now for the logic game. Those numbers mean something. They tell you how many mines are in the eight adjacent squares to it.

I'm not going to tell you all the patterns I've learned because that's part of the fun. But I suggest you start with the biggest board size you can to learn the patterns and just accept you're gonna lose your first several games.
A word of warning: there are certain times where there simply isn't enough information to figure out which of two squares a mine could be in(usually on the edge of the map). I suggest you follow a simple process.

Save it for the very end. This will give you time to finish the rest of the map and make the next step a viable solution.
Consider the number of mines left in the game. Often, there is one solution to this issue when there is one mine left, and another when there is two, or none.
Guess. Sometimes there's nothing you can do but guess. Alas, a 50/50 shot is all you're gonna get.
