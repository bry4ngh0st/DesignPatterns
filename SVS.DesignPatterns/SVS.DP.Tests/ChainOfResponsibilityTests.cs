using NUnit.Framework;
using SVS.DP.Patterns.ChainOfResponsibility.Handlers;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class ChainOfResponsibilityTests
    {
        [TestCase("word")]
        [TestCase("excel")]
        [TestCase("pdf")]
        public void Main(string file)
        {
            var wordHandler = new WordHandler();
            var pdfHandler = new PdfHandler();
            var excelHandler = new ExcelHandler();

            wordHandler.SetSuccessor(pdfHandler);
            pdfHandler.SetSuccessor(excelHandler);

            wordHandler.Process(file);
        }
    }
}
