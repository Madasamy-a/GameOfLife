Conway's Game of Life, also known as the Game of Life is actually a zero-player game, 
meaning that its evolution is determined by its initial state, needing no input from human players.
One interacts with the Game of Life by creating an initial population and observing how it evolves.

Rules : 
The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead.

Every cell interacts with its eight neighbours, which are the cells that are directly horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:
Any live cell with fewer than two live neighbours dies (referred to as underpopulation).
Any live cell with more than three live neighbours dies (referred to as overpopulation).
Any live cell with two or three live neighbours lives, unchanged, to the next generation.
Any dead cell with exactly three live neighbours will come to life.

The initial pattern constitutes the 'seed' of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed — births and deaths happen simultaneously.
In other words, each generation is a pure function of the one before.
The rules continue to be applied repeatedly to create further generations.


Objective:
For a universe whose grid-size is (25,25), assuming the initial population (Generation 0) is seeded in the grid, write a program to find the population pattern in N-th generation.
For input, assume that line 1 is the generation we are interested in to know its population; followed by positions of live cells in generation-0 seeded as input configuration.
See sample input and expected output below for demo/testing purposes. You are free to input the data either via console or simple text file.


Input Spec:
Which generations's population positions are you interested in?
Input the population positions of Generation ZERO.
Output Spec:
List of positions of living population.

Sample Input 1:
3 
2 1
2 2
2 3
Output:
[(1,2), (2,2), (3,2)]

Sample Input 2:
5
9 8
10 9
8 10
9 10
10 10
Output:
[(9,10), (10,11), (10,12), (11,10), (11,11)]

Sample Input 3:
10
1 2
2 1
2 3
3 2
Output:
[(1,2), (2,1), (2,3), (3,2)]


Hint:
To know that the program works as you would expect it to work, you can print out the state of the universe to the console/output after each generation. 
You are free to learn more about Game of Life in https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life.

Note: 
- There is no need to build a custom UI. You score no extra point for it.
- This problem needs to be solved using C# programming language only, if you are applying as Backend Developer Architect.
- This problem needs to be solved using Javascript/Typescript programming language only, if you are applying as Frontend Developer Architect.


What we look for in your solution:
- Your problem solving ability
- Your programming expertise
- Your skills in Object Oriented Programming
- Your comfort level in Git/Github. 
- You score Bonus points if you test-drive your code or at the very least have unit-tests in place.