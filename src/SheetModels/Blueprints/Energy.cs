using System.Collections.Generic;

namespace SheetModels.Blueprints
{
    public sealed class Energy
    {
        public uint DiscountEnergy { get; init; }
        public uint SurchargeEnergy { get; init; }
        public uint SuggestEnergy { get; init; }
        public uint SpeedUpEnergy { get; init; }

        public static Energy FromRaw(IList<object> raw)
        {
            return new()
            {
                DiscountEnergy = raw[0].Parse<uint>(),
                SurchargeEnergy = raw[1].Parse<uint>(),
                SuggestEnergy = raw[2].Parse<uint>(),
                SpeedUpEnergy = raw[3].Parse<uint>()
            };
        }
    }
}
