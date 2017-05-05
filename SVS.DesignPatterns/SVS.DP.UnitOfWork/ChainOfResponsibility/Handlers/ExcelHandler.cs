using System;

namespace SVS.DP.Patterns.ChainOfResponsibility.Handlers
{
    public class ExcelHandler : Handler
    {
        public override void Process(string file)
        {
            if (file.Equals("excel"))
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
