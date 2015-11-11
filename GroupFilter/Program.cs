using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\work\SPV\TAX14_ODINMERGE.grp");
            string[] linesToDelete = System.IO.File.ReadAllLines(@"C:\work\SPV\LinesToREmove.txt");

            List<String> linesToWrite = new List<String>();

            foreach (String line in lines)
            {
                if(line.StartsWith(","))
                {
                    continue;
                }
                
                Boolean remove = false;
                String testString = line.Replace(",", "");

                foreach (String removeLine in linesToDelete)
                { 
                    if(removeLine.Equals(testString))
                    {
                        remove = true;
                        break;
                    }
                }
                if(!remove)
                    linesToWrite.Add(line + ",");
            }

            System.IO.File.WriteAllLines(@"C:\work\SPV\output.txt", linesToWrite);
        }
    }
}
