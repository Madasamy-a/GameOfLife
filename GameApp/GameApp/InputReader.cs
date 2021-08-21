using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace GameApp
{
    /// <summary>
    /// Read the input file and parse the data
    /// </summary>
    class InputReader
    {

        public int Generation { get; set; }

        public List<int[]> Values { get; set; }

        /// <summary>
        /// Read all the data and parse the information
        /// </summary>
        public void ReadAllData()
        {
            Values = new List<int[]>();
            bool hasReadFirstLine = false;
            string line;
            string startupPath = Environment.CurrentDirectory;
            string filePath = Path.Combine(startupPath, @"..\..\..", @"input-data.txt");
            if(!File.Exists(filePath))
            {
                Console.WriteLine("Input file does not exist");
                return;
            }
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                if(!hasReadFirstLine)
                {
                    int generationInput = 0;
                    bool hasValue = Int32.TryParse(line, out generationInput);
                    if(hasValue)
                    {
                        Generation = generationInput;
                    }
                    hasReadFirstLine = true;
                    continue;
                }
                int[] data = GetData(line);
                if(data != null)
                {
                    Values.Add(data);
                }
            }
        }

        /// <summary>
        /// Split the line in to two integer values
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int[] GetData(string data)
        {
            int[] values = new int[2];
            bool hasFirstValue = false;
            bool hasSecondValue = false;
            string[] splittedData = data.Split( ' ', StringSplitOptions.RemoveEmptyEntries);
            if( splittedData.Length == 2)
            {
                hasFirstValue = Int32.TryParse(splittedData[0], out values[0]);
                hasSecondValue = Int32.TryParse(splittedData[1], out values[1]);
            }

            return (hasFirstValue && hasSecondValue) ? values : null;
        }
    }
}
