using System;

namespace SVS.DP.Patterns.ChainOfResponsibility.Handlers
{
    public class WordHandler : Handler
    {
        public override void Process(string file)
        {
            if (file.Equals("word"))
            {
                Console.WriteLine($"Processing a {file} file");
            }
            else if (_successor != null)
            {
                _successor.Process(file);
            }
        }
    }
}
