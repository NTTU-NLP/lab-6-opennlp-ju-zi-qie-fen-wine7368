using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using opennlp.tools.sentdetect;


namespace LAB6
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader str = new StreamReader(@"..\..\tokenization\Data.txt");
            StreamWriter stw = new StreamWriter(@"..\..\tokenization\Result.txt");
            while (str.Peek() != -1)
            {
                string line = str.ReadLine();
                java.io.InputStream modelIn = new java.io.FileInputStream("en-sent.bin");
                SentenceModel smodel = new SentenceModel(modelIn);
                SentenceDetector detector = new SentenceDetectorME(smodel);
                string[] sents = detector.sentDetect(line);
                foreach (var sent in sents)
                {
                    stw.WriteLine(sent);
                    stw.WriteLine();
                }
                stw.Flush();
            }
            str.Close();
            stw.Close();
        }
    }
}
