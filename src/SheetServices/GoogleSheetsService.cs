using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;

namespace SheetServices
{
    public sealed class GoogleSheetsService
    {
        static string[] Scopes = {SheetsService.Scope.SpreadsheetsReadonly};
        static string ApplicationName = "Shop Titans Spreadsheet Fetcher";
        private readonly FileInfo _credentialsPath;

        private SheetsService _sheetsService;

        // Shop Titans their SpreadsheetId
        private const string SpreadsheetId = "1WLa7X8h3O0-aGKxeAlCL7bnN8-FhGd3t7pz2RCzSg8c";

        public GoogleSheetsService(FileInfo credentialsPath)
        {
            _credentialsPath = credentialsPath;
        }

        public IList<IList<object>> FetchValueRange(string range)
        {
            var request = GetSheetsService().Spreadsheets.Values.Get(SpreadsheetId, range);
            return request.Execute().Values;
        }

        private SheetsService GetSheetsService()
        {
            if (_sheetsService == null)
            {
                UserCredential credential;
                using (var stream = File.OpenRead(_credentialsPath.FullName))
                {
                    const string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                        Scopes, "user", CancellationToken.None, new FileDataStore(credPath)).Result;
                }

                var service = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                _sheetsService = service;
            }

            return _sheetsService;
        }
    }
}
