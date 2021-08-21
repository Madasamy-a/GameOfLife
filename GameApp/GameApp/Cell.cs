using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameApp
{
    class Cell
    {
        public bool IsAlive { get; set; }

        private List<Cell> siblings = new List<Cell>();
        public Cell()
        {
            IsAlive = false;
        }

        /// <summary>
        /// Add siblings to the cell
        /// </summary>
        /// <param name="siblingCell"></param>
        public void AddSibling(Cell siblingCell)
        {
            siblings.Add(siblingCell);
        }

        /// <summary>
        /// Find the status of the cell for next generation
        /// </summary>
        /// <param name="manager"></param>
        public void AnalyzeCellForNextGeneration(PopulationManager manager)
        {
            const int UNDER_POPULATION_COUNT = 2;
            const int OVER_POPULATION_COUNT = 3;
            const int NEW_GENERATION_POPULATION_COUNT = 3;

            int aliveNeighbours = siblings.Count(cell => cell.IsAlive);
            if (IsAlive)
            {
                if (aliveNeighbours < UNDER_POPULATION_COUNT)
                {
                    //Died because of under population
                    manager.deadCells.Add(this);
                }
                else if (aliveNeighbours > OVER_POPULATION_COUNT)
                {
                    //Died because of over population
                    manager.deadCells.Add(this);
                }
                else
                {
                    manager.remainingCells.Add(this);
                }
            }
            else
            {
                if (aliveNeighbours == NEW_GENERATION_POPULATION_COUNT)
                {
                    manager.aliveCells.Add(this);
                }
                else
                {
                    manager.remainingCells.Add(this);
                }
            }
        }
    }
}
