using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PassConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string output;
            var result = new List<IEntry>();

            if (args == null || args.Length == 0)
            {
                input = Constants.InputFile;
                output = Constants.OutputFile;
            }
            else 
            { 
                input = args[0];
                output = args[1];
            }

            if (!File.Exists(input))
            {
                Console.WriteLine("input file does not exist");
                return;
            }
            using (var sr = new StreamReader(input, Encoding.Default))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    try
                    {
                        var line = currentLine.Split(Constants.InputDelimiter);
                        result.Add(new Entry(line));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }
            using (var writer = new StreamWriter(output, false, Encoding.Default))
            {
                writer.WriteLine(@"url,type,username,password,hostname,extra,name,grouping");

                foreach (var entry in result)
                {
                    writer.WriteLine(entry.ToCSVString());
                }

                writer.Flush();
            }

            Console.WriteLine("done.");
        }

        
    }
}