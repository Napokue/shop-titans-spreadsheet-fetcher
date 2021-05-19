using System.Collections.Generic;
using SheetServices.Blueprints;
using SheetServices.WorkerLevels;
using SheetServices.Workers;

namespace SheetServices
{
    public class SpreadsheetFetcher
    {
        private readonly GoogleSheetsService _sheetsService;

        public SpreadsheetFetcher(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        public IEnumerable<SheetModels.Blueprints.Blueprint> FetchBluePrints(
            BlueprintsFetchFlags fetchFlags = BlueprintsFetchFlags.All)
        {
            var blueprintsFetcher =
                new BlueprintsFetcher(_sheetsService, fetchFlags);
            return blueprintsFetcher.FetchModels();
        }

        public IEnumerable<SheetModels.Workers.Worker> FetchWorkers()
        {
            var workersFetcher =
                new WorkersFetcher(_sheetsService);
            return workersFetcher.FetchModels();
        }

        public IEnumerable<SheetModels.WorkerLevels.WorkerLevel> FetchWorkerLevels()
        {
            var workerLevelsFetcher =
                new WorkerLevelsFetcher(_sheetsService);
            return workerLevelsFetcher.FetchModels();
        }
    }
}
