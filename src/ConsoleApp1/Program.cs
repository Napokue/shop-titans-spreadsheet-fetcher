using System;
using System.IO;
using System.Linq;
using SheetServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var googleSheetsService = new GoogleSheetsService(new FileInfo(args[0]));
            
            var spreadsheetFetcher = new SpreadsheetFetcher(googleSheetsService);

            var blueprints = spreadsheetFetcher.FetchBluePrints().ToList();
        }
    }
}
