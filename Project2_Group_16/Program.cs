using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_16
{
    class Program
    {
        static void Main()
        {
            // first let's parse the csv file to get infix expressions
            List<string> inFix = CSVFile.CSVDeserialize();

            // create the lists that would hold the converted values
            List<PreFix> preFix = new List<PreFix>();
            List<PostFix> postFix = new List<PostFix>();
            foreach(string val in inFix)
            {
                string[] snoAndInfix = val.Split(',');

                // add values after they get converted in the constructor
                preFix.Add(new PreFix(snoAndInfix[1]));
                postFix.Add(new PostFix(snoAndInfix[1]));
            }

            Console.ReadKey();
        }
    }
}
