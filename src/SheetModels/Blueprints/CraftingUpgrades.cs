using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public class CraftingUpgrades
    {
        public string CraftingUpgrade1 { get; init; }
        public uint CraftsNeeded1 { get; init; }
        public string CraftingUpgrade2 { get; init; }
        public uint CraftsNeeded2 { get; init; }
        public string CraftingUpgrade3 { get; init; }
        public uint CraftsNeeded3 { get; init; }
        public string CraftingUpgrade4 { get; init; }
        public uint CraftsNeeded4 { get; init; }
        public string CraftingUpgrade5 { get; init; }
        public uint CraftsNeeded5 { get; init; }

        public static CraftingUpgrades FromRaw(IList<object> raw)
        {
            return new()
            {
                CraftingUpgrade1 = raw[0].Parse<string>(),
                CraftsNeeded1 = raw[1].Parse<uint>(),
                CraftingUpgrade2 = raw[2].Parse<string>(),
                CraftsNeeded2 = raw[3].Parse<uint>(),
                CraftingUpgrade3 = raw[4].Parse<string>(),
                CraftsNeeded3 = raw[5].Parse<uint>(),
                CraftingUpgrade4 = raw[6].Parse<string>(),
                CraftsNeeded4 = raw[7].Parse<uint>(),
                CraftingUpgrade5 = raw[8].Parse<string>(),
                CraftsNeeded5 = raw[9].Parse<uint>()
            };
        }
    }
}
