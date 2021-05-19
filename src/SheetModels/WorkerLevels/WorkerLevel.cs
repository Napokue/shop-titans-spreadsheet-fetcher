using System.Collections.Generic;
using Newtonsoft.Json;

namespace SheetModels.WorkerLevels
{
    public class WorkerLevel
    {
        [JsonProperty("WorkerLevel")]
        public uint WorkerLevelValue { get; init; }
        public uint XpNeeded { get; init; }
        public string CraftingSpeedBonus { get; init; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static WorkerLevel FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WorkerLevel>(json);
        }

        public static WorkerLevel FromRaw(IList<object> raw)
        {
            return new()
            {
                WorkerLevelValue = raw[0].Parse<uint>(),
                XpNeeded = raw[1].Parse<uint>(),
                CraftingSpeedBonus = raw[2].Parse<string>()
            };
        }
    }
}
