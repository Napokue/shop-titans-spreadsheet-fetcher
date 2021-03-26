using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Components
    {
        public string Component1 { get; init; }
        public string ComponentQuality1 { get; init; }
        public uint AmountNeeded1 { get; init; }
        public string Component2 { get; init; }
        public string ComponentQuality2 { get; init; }
        public uint AmountNeeded2 { get; init; }

        public static Components FromRaw(IList<object> raw)
        {
            return new()
            {
                Component1 = raw[0].Parse<string>(),
                ComponentQuality1 = raw[1].Parse<string>(),
                AmountNeeded1 = raw[2].Parse<uint>(),
                Component2 = raw[3].Parse<string>(),
                ComponentQuality2 = raw[4].Parse<string>(),
                AmountNeeded2 = raw[5].Parse<uint>()
            };
        }
    }
}
