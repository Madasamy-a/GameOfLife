using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace GameApp
{
    class Universe
    {
        const int GRID_WIDTH = 25;
        const int GRID_HEIGHT = 25;

        public Cell[,] cellArray;

        public delegate void GeneratePopulation(PopulationManager manager);
        public event GeneratePopulation populationGenerator;

        public PopulationManager manager = new PopulationManager();

        public Universe()
        {
            cellArray = new Cell[GRID_HEIGHT, GRID_WIDTH];
        }

        /// <summary>
        /// Do all the complete operation needed for the game
        /// </summary>
        public void StartProcess()
        {
            InputReader reader = new InputReader();
            reader.ReadAllData();
            Console.WriteLine("Generation : " + reader.Generation);
            InitUniverse(reader.Values);
            PrintPopulation("Initial Population");
            AddSiblings();
            for(int index = 1; index <= reader.Generation; index++)
            {
                InvokeGeneratePopulation();
                PrintPopulation("Population of Generation " + index);
            }
            Console.WriteLine("Process Complete");
            Console.ReadKey();
        }

        /// <summary>
        /// Initialize the data 
        /// </summary>
        /// <param name="initialValues"></param>
        public void InitUniverse(List<int[]> initialValues)
        {
            //Initialize default data
            for (int rowIndex = 0; rowIndex < GRID_HEIGHT; rowIndex++)
            {
                for (int colIndex = 0; colIndex < GRID_WIDTH; colIndex++)
                {
                    cellArray[rowIndex, colIndex] = new Cell();
                    populationGenerator += cellArray[rowIndex, colIndex].AnalyzeCellForNextGeneration;
                }
            }

            //Apply alive details
            initialValues.ForEach((int[] data) => cellArray[data[0],data[1]].IsAlive = true);

        }

        /// <summary>
        /// Print the current population
        /// </summary>
        /// <param name="title"></param>
        public void PrintPopulation(string title)
        {
            Console.WriteLine(title);
            for (int rowIndex = 0; rowIndex < GRID_HEIGHT; rowIndex++)
            {
                for (int colIndex = 0; colIndex < GRID_WIDTH; colIndex++)
                {
                    Console.Write(cellArray[rowIndex, colIndex].IsAlive ? "#" : "*");
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            string format = " ({0},{1}),";
            for (int rowIndex = 0; rowIndex < GRID_HEIGHT; rowIndex++)
            {
                for (int colIndex = 0; colIndex < GRID_WIDTH; colIndex++)
                {
                    if (cellArray[rowIndex, colIndex].IsAlive)
                    {
                        builder.Append(String.Format(format, rowIndex, colIndex));
                    }
                }
            }
            //Remove the trailing comma if it has data
            if (builder.Length > 1)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append(" ]");
            Console.WriteLine(builder.ToString());
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Pass the event to all cells to calculate the next generation
        /// </summary>
        public void InvokeGeneratePopulation()
        {
            populationGenerator?.Invoke(manager);
            Thread.Sleep(500);
            int totalCells = GRID_HEIGHT * GRID_WIDTH;
            while (!manager.IsAllCellsUpdated(totalCells))
            {
                Thread.Sleep(500);
            }
            manager.ResetPopulation();
        }

        /// <summary>
        /// Find each cells siblings and add to the siblings list
        /// </summary>
        public void AddSiblings()
        {
            Console.WriteLine();
            for (int rowIndex = 0; rowIndex < GRID_HEIGHT; rowIndex++)
            {
                for (int colIndex = 0; colIndex < GRID_WIDTH; colIndex++)
                {
                    //Console.WriteLine("Sibling of [" + rowIndex + " " + colIndex + "]");

                    for (int rIndex = -1; rIndex <= 1; rIndex++)
                    {
                        for (int cIndex = -1; cIndex <= 1; cIndex++)
                        {
                            int siblingRowIndex = rowIndex + rIndex;
                            int siblingColIndex = colIndex + cIndex;

                            if(siblingRowIndex < 0 || siblingRowIndex >= GRID_HEIGHT
                                || siblingColIndex < 0 || siblingColIndex >= GRID_WIDTH)
                            {
                                //sibling index is out of the GRID
                                continue;
                            }

                            if(siblingRowIndex == rowIndex && siblingColIndex == colIndex)
                            {
                                //The cell is not sibling to itself
                                continue;
                            }
                            cellArray[rowIndex, colIndex].AddSibling(cellArray[siblingRowIndex, siblingColIndex]);

                            //Console.Write("[" + siblingRowIndex + " " + siblingColIndex + "] ");
                        }
                    }
                    //Console.WriteLine();
                    //Console.WriteLine("-----------------------------------------------");
                }
            }
        }

    }
}
