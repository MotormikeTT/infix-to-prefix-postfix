using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace Project2_Group_16
{
    public static class XMLExtension
    {
        // This method includes xml version and encoding
        public static void WriteStartDocument(this StreamWriter writer)
        {
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        }
        // This method adds the root tag to the file
        public static void WriteStartRootElement(this StreamWriter writer)
        {
            writer.WriteLine("<root>");      
        }
        // This method ends the root tag
        public static void WriteEndRootElement(this StreamWriter writer)
        {
            writer.WriteLine("</root>");
        }
        // This method adds the element tag to the file
        public static void WriteStartElement(this StreamWriter writer)
        {
            writer.WriteLine("<element>");      
        }
        // This method ends the element tag
        public static void WriteEndElement(this StreamWriter writer)
        {
            writer.WriteLine("</element>");           
        }
        // This method adds each attribute with its values
        public static void WriteAttribute(this StreamWriter writer, string attribute, string value)
        {
            writer.WriteLine($"<{attribute}>{value}</{attribute}>");
        }
        // Write XML file
        public static void WriteXMLFile(List<string> inFix, List<PreFix> preFix, List<PostFix> postFix)
        {
            try
            {
                FileStream fs = new FileStream("../../Data/Project 2_INFO_5101.xml", FileMode.Create);
                StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
                int i = 0;
                writer.WriteStartDocument();
                writer.WriteStartRootElement();
                foreach (string val in inFix)
                {
                    string[] snoAndInfix = val.Split(',');

                    writer.WriteStartElement();
                    writer.WriteAttribute("sno", snoAndInfix[0].ToString());
                    writer.WriteAttribute("infix", snoAndInfix[1].ToString());
                    writer.WriteAttribute("prefix", preFix[i].ToString());
                    writer.WriteAttribute("postfix", postFix[i].ToString());
                    writer.WriteAttribute("evaluation", "");
                    writer.WriteAttribute("comparison", "");
                    writer.WriteEndElement();

                    i++;
                }
                writer.WriteEndRootElement();
                writer.Flush();
                writer.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Open XML file on web browser
        public static void OpenXMLWeb()
        {
            FileStream fs = new FileStream("../../Data/Project 2_INFO_5101.xml", FileMode.Open);
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = fs.Name;
            process.Start();
        }
    }
}
