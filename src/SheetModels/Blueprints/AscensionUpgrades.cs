using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class AscensionUpgrades
    {
        public string AscensionUpgrade1 { get; init; }
        public uint ShardsNeeded1 { get; init; }
        public string AscensionUpgrade2 { get; init; }
        public uint ShardsNeeded2 { get; init; }
        public string AscensionUpgrade3 { get; init; }
        public uint ShardsNeeded3 { get; init; }

        public static AscensionUpgrades FromRaw(IList<object> raw)
        {
            return new()
            {
                AscensionUpgrade1 = raw[0].Parse<string>(),
                ShardsNeeded1 = raw[1].Parse<uint>(),
                AscensionUpgrade2 = raw[2].Parse<string>(),
                ShardsNeeded2 = raw[3].Parse<uint>(),
                AscensionUpgrade3 = raw[4].Parse<string>(),
                ShardsNeeded3 = raw[5].Parse<uint>()
            };
        }
    }
}
