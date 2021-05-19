using System.Collections.Generic;
using SheetModels.WorkerLevels;

namespace SheetServices.WorkerLevels
{
    public class WorkerLevelsFetcher : AbstractFetcher<WorkerLevel>
    {
        public WorkerLevelsFetcher(GoogleSheetsService sheetsService) : base(sheetsService)
        {
        }

        public override IEnumerable<WorkerLevel> FetchModels()
        {
            return FetchWorkerLevels();
        }

        private IEnumerable<WorkerLevel> FetchWorkerLevels() =>
            Fetch(SheetRanges.WorkerLevelsRanges.WorkerLevelsRange, WorkerLevel.FromRaw);
    }
}
