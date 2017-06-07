using System;
using System.IO;

namespace cb
{
    class Wordlist
    {
        //Pick Word:
        public string pickWord()
        {
            var lineCount = File.ReadAllLines(@"wordlist.txt").Length;
            Random rnd = new Random();
            int line = rnd.Next(0, lineCount);
            StreamReader sr = new StreamReader(@"wordlist.txt");
            int times = 0;

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                times++;

                if (line == times)
                {
                    return text;
                }
            }

            return null;
        }
    }
}