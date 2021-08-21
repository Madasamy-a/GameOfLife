using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp
{
    class PopulationManager
    {
        public List<Cell> aliveCells = new List<Cell>();
        public List<Cell> deadCells = new List<Cell>();
        public List<Cell> remainingCells = new List<Cell>();

        /// <summary>
        /// Check whether all cells are added. It is to check all the events are completed
        /// </summary>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public bool IsAllCellsUpdated(int totalCount)
        {
            int calcCount = aliveCells.Count + deadCells.Count + remainingCells.Count;
            return (totalCount == calcCount) ? true : false;
        }

        /// <summary>
        /// Set the population for the next generation
        /// </summary>
        public void ResetPopulation()
        {
            //Set the IsAlive property for next generation
            aliveCells.ForEach(eachCell => eachCell.IsAlive = true);
            deadCells.ForEach(eachCell => eachCell.IsAlive = false);
            Clear();
        }

        /// <summary>
        /// Clear the list to calculate the next to next generation
        /// </summary>
        public void Clear()
        {
            aliveCells.Clear();
            deadCells.Clear();
            remainingCells.Clear();
        }
    }
}
