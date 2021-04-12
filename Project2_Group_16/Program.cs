using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project2_Group_16
{
    class Program
    {
        static void Main()
        {
            CompareExpressions compare = new CompareExpressions();

            // first let's parse the csv file to get infix expressions
            List<string> inFix = CSVFile.CSVDeserialize("../../Data/Project 2_INFO_5101.csv");

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

            // display summary report
            Console.WriteLine("".PadRight(113, '='));
            Console.WriteLine("Summary Report".PadLeft(63, ' '));
            Console.WriteLine("".PadRight(113, '='));

            Console.WriteLine($"\n|{"Sno",5}|{"Infix",20}|{"PreFix",20}|{"PostFix",20}|{"PreFix Res",15}|{"PostFix Res",15}|{"Match",10}|");
            Console.Write("".PadRight(113, '='));

            int i = 0;
            foreach(string val in inFix)
            {
                string[] snoAndInfix = val.Split(',');
                Console.Write($"\n|{snoAndInfix[0],5}|");
                Console.Write($"{snoAndInfix[1],20}|");
                Console.Write($"{preFix[i],20}|");
                Console.Write($"{postFix[i],20}|");
                Console.Write($"{preFix[i].Result,15}|");    // result
                Console.Write($"{postFix[i].Result,15}|");    // result
                Console.Write($"{Convert.ToBoolean(compare.Compare(preFix[i].Result, postFix[i].Result)), 10}|");    // match

                i++;
            }
            Console.WriteLine($"\n{"".PadRight(113, '=')}");

            // write XML file
            XMLExtension.WriteXMLFile(inFix, preFix, postFix);

            Console.Write($"\nXML file generated. Would you like to open in a web browser? (Y/N): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                // open XML file in web browser
                XMLExtension.OpenXMLWeb();
            }
        }
    }
}
