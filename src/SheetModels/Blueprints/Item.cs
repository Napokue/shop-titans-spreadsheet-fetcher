using System;
using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Item
    {
        public string Name { get; init; }
        public string Type { get; init; }
        public string UnlockPrerequisite { get; init; }
        public uint ResearchScrolls { get; init; }
        public uint AntiqueTokens { get; init; }
        public byte Tier { get; init; }
        public uint Value { get; init; }
        public string CraftingTimeSeconds { get; init; }
        public string CraftingTimeFormatted { get; init; }
        public float ValueCraftingTime { get; init; }
        public uint MerchantXp { get; init; }
        public float MerchantXpCraftingTime { get; init; }
        public uint WorkerXp { get; init; }
        public uint FusionXp { get; init; }
        public uint Favor { get; init; }

        public static Item FromRaw(IList<object> raw)
        {
            return new()
            {
                Name = raw[0].Parse<string>(),
                Type = raw[1].Parse<string>(),
                UnlockPrerequisite = raw[2].Parse<string>(),
                ResearchScrolls = raw[3].Parse<uint>(),
                AntiqueTokens = raw[4].Parse<uint>(),
                Tier = raw[5].Parse<byte>(),
                Value = raw[6].Parse<uint>(),
                CraftingTimeSeconds = raw[7].Parse<string>(),
                CraftingTimeFormatted = raw[8].Parse<string>(),
                ValueCraftingTime = raw[9].Parse<float>(),
                MerchantXp = raw[10].Parse<uint>(),
                MerchantXpCraftingTime = raw[11].Parse<float>(),
                WorkerXp = raw[12].Parse<uint>(),
                FusionXp = raw[13].Parse<uint>(),
                Favor = raw[14].Parse<uint>()
            };
        }
    }
}
