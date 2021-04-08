using System;
using System.Collections.Generic;

namespace Project2_Group_16
{
    /// <summary>
    /// Compare results out of the conversion processes
    /// </summary>
    class CompareExpressions : IComparer<string>
    {
        public int Compare(string value1, string value2)
        {
            double v1 = Double.Parse(value1);
            double v2 = Double.Parse(value2);
            if (v1 == v2)
                return 1;
            else
                return 0;
        }
    }
}
