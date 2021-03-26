using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using SheetModels.Blueprints;
using SheetServices.Blueprints;

namespace SheetServices
{
    public class SpreadsheetFetcher
    {
        private GoogleSheetsService _sheetsService;

        public SpreadsheetFetcher(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        public IEnumerable<SheetModels.Blueprints.Blueprint> FetchBluePrints()
        {
            var blueprintsFetcher =
                new BlueprintsFetcher(_sheetsService, BlueprintsFetchFlags.All);
            return blueprintsFetcher.FetchBlueprints();
        }
    }
}
