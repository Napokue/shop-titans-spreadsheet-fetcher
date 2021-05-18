using System;
using System.Collections.Generic;

namespace SheetServices
{
    public abstract class AbstractFetcher<T>
    {
        protected readonly GoogleSheetsService _sheetsService;

        protected AbstractFetcher(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        public abstract IEnumerable<T> FetchModels();

        protected IEnumerable<TModel> Fetch<TModel>(string range, Func<IList<object>, TModel> fromRaw)
        {
            var rawCollection = _sheetsService.FetchValueRange(range);
            
            // Skip first element, as the first element of rows are the headers
            for (var i = 1; i < rawCollection.Count; i++)
            {
                var raw = rawCollection[i];
                yield return fromRaw(raw);
            }
        }

    }
}
