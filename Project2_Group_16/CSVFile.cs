using System.Collections.Generic;
using System.IO;
using System;

namespace Project2_Group_16
{
    static class CSVFile
    {
        /// <summary>
        /// Dump the content of the CSV file to a list
        /// </summary>
        public static List<string> CSVDeserialize(string fileName)
        {
            List<string> csvData = new List<string>(File.ReadAllLines(fileName));
            // remove header
            csvData.RemoveAt(0);

            return csvData;
        }
    }
}
