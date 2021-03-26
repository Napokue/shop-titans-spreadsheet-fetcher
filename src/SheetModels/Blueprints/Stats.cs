using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Stats
    {
        public uint Atk { get; init; }
        public uint Def { get; init; }
        public uint Hp { get; init; }
        public float Eva { get; init; }
        public float Crit { get; init; }

        public static Stats FromRaw(IList<object> raw)
        {
            return new()
            {
                Atk = raw[0].Parse<uint>(),
                Def = raw[1].Parse<uint>(),
                Hp = raw[2].Parse<uint>(),
                Eva = raw[3].Parse<float>(),
                Crit = raw[4].Parse<float>()
            };
        }
    }
}
