using System.IO;
using System.Linq;
using SheetServices;
using SheetServices.Blueprints;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var googleSheetsService = new GoogleSheetsService(new FileInfo(args[0]));
            
            var spreadsheetFetcher = new SpreadsheetFetcher(googleSheetsService);
            var bluePrints = spreadsheetFetcher.FetchBluePrints(BlueprintsFetchFlags.Components).ToList();
            var workers = spreadsheetFetcher.FetchWorkers().ToList();
        }
    }
}
