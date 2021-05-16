using System.IO;
using System.Linq;
using SheetModels.Blueprints;
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

            var bluePrintsJson = spreadsheetFetcher.FetchBluePrints().Select(blueprint => blueprint.ToJson()).ToList();

            spreadsheetFetcher.FetchBluePrints(BlueprintsFetchFlags.Components);
            var blueprints = bluePrintsJson.Select(Blueprint.FromJson).ToList();
        }
    }
}
