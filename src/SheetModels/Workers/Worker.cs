using System.Collections.Generic;
using Newtonsoft.Json;
using SheetModels.Blueprints;

namespace SheetModels.Workers
{
    public class Worker
    {
        [JsonProperty("Worker")]
        public string WorkerType { get; init; }
        public string Name { get; init; }
        public uint LevelRequired { get; init; }
        public string BuildingPrerequisite { get; init; }
        public uint GoldCost { get; init; }
        public uint GemCost { get; init; }
        public string BlueprintUnlocks { get; init; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Worker FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Worker>(json);
        }
        
        public static Worker FromRaw(IList<object> raw)
        {
            return new()
            {
                WorkerType = raw[0].Parse<string>(),
                Name = raw[1].Parse<string>(),
                LevelRequired = raw[2].Parse<uint>(),
                BuildingPrerequisite = raw[3].Parse<string>(),
                GoldCost = raw[4].Parse<uint>(),
                GemCost = raw[5].Parse<uint>(),
                BlueprintUnlocks = raw[6].Parse<string>()
            };
        }
    }
}
