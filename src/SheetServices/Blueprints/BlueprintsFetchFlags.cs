using System;

namespace SheetServices.Blueprints
{
    [Flags]
    public enum BlueprintsFetchFlags
    {
        Item = 0x1,
        Workers = 0x2,
        Resources = 0x4,
        Components = 0x8,
        Stats = 0x10,
        CraftingUpgrades = 0x20,
        AscensionUpgrades = 0x40,
        Energy = 0x80,
        All = Item | Workers | Resources | Components | Stats | CraftingUpgrades | AscensionUpgrades | Energy
    }
}
