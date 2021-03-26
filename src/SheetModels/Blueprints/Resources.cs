using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Resources
    {
        public uint Iron { get; init; }
        public uint Wood { get; init; }
        public uint Leather { get; init; }
        public uint Herbs { get; init; }
        public uint Steel { get; init; }
        public uint Ironwood { get; init; }
        public uint Fabric { get; init; }
        public uint Oils { get; init; }
        public uint Mana { get; init; }
        public uint Gems { get; init; }

        public static Resources FromRaw(IList<object> raw)
        {
            return new()
            {
                Iron = raw[0].Parse<uint>(),
                Wood = raw[1].Parse<uint>(),
                Leather = raw[2].Parse<uint>(),
                Herbs = raw[3].Parse<uint>(),
                Steel = raw[4].Parse<uint>(),
                Ironwood = raw[5].Parse<uint>(),
                Fabric = raw[6].Parse<uint>(),
                Oils = raw[7].Parse<uint>(),
                Mana = raw[8].Parse<uint>(),
                Gems = raw[9].Parse<uint>()
            };
        }
    }
}
