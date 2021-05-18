using System.Collections.Generic;
using SheetModels.Workers;

namespace SheetServices.Workers
{
    public class WorkersFetcher : AbstractFetcher<Worker>
    {
        public WorkersFetcher(GoogleSheetsService sheetsService) : base(sheetsService)
        {
        }

        public override IEnumerable<Worker> FetchModels()
        {
            return FetchWorkers();
        }

        private IEnumerable<Worker> FetchWorkers() =>
            Fetch(SheetRanges.WorkersRanges.WorkersRange, Worker.FromRaw);
    }
}
