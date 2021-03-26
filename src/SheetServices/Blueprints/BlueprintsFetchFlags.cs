using System;

namespace SheetServices.Blueprints
{
    [Flags]
    public enum BlueprintsFetchFlags
    {
        Item,
        Workers,
        Resources,
        Components,
        Stats,
        CraftingUpgrades,
        AscensionUpgrades,
        Energy,
        All = Item | Workers | Resources | Components | Stats | CraftingUpgrades | AscensionUpgrades | Energy
    }
}
