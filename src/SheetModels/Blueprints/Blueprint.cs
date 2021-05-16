using Newtonsoft.Json;

namespace SheetModels.Blueprints
{
    public sealed class Blueprint
    {
        public Item Item { get; init; }
        public Worker Worker { get; init; }
        public Resources Resources { get; init; }
        public Components Components { get; init; }
        public Stats Stats { get; init; }
        public CraftingUpgrades CraftingUpgrades { get; init; }
        public AscensionUpgrades AscensionUpgrades { get; init; }
        public Energy Energy { get; init; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Blueprint FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Blueprint>(json);
        }
    }
}
