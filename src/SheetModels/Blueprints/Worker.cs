using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Worker
    {
        public string RequiredWorker1 { get; init; }
        public uint WorkerLevel1 { get; init; }
        public string RequiredWorker2 { get; init; }
        public uint WorkerLevel2 { get; init; }
        public string RequiredWorker3 { get; init; }
        public uint WorkerLevel3 { get; init; }

        public static Worker FromRaw(IList<object> raw)
        {
            return new()
            {
                RequiredWorker1 = raw[0].Parse<string>(),
                WorkerLevel1 = raw[1].Parse<uint>(),
                RequiredWorker2 = raw[2].Parse<string>(),
                WorkerLevel2 = raw[3].Parse<uint>(),
                RequiredWorker3 = raw[4].Parse<string>(),
                WorkerLevel3 = raw[5].Parse<uint>()
            };
        }
    }
}
