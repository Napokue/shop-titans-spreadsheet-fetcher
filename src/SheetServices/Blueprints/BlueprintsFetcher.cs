using System;
using System.Collections.Generic;
using System.Linq;
using SheetModels.Blueprints;

namespace SheetServices.Blueprints
{
    internal class BlueprintsFetcher
    {
        private readonly GoogleSheetsService _sheetsService;
        private readonly BlueprintsFetchFlags _flags;

        public BlueprintsFetcher(
            GoogleSheetsService sheetsService,
            BlueprintsFetchFlags flags = BlueprintsFetchFlags.Item)
        {
            _sheetsService = sheetsService;

            if (!flags.HasFlag(BlueprintsFetchFlags.Item))
            {
                throw new ArgumentException($"{nameof(flags)} needs to have flag: {BlueprintsFetchFlags.Item}");
            }
            _flags = flags;
        }

        public IEnumerable<Blueprint> FetchBlueprints()
        {
            var items = FetchItem().ToList();
            IList<Worker> workers = Array.Empty<Worker>();
            IList<Resources> resources = Array.Empty<Resources>();
            IList<Components> components = Array.Empty<Components>();
            IList<Stats> stats = Array.Empty<Stats>();
            IList<CraftingUpgrades> craftingUpgrades = Array.Empty<CraftingUpgrades>();
            IList<AscensionUpgrades> ascensionUpgrades = Array.Empty<AscensionUpgrades>();
            IList<Energy> energy = Array.Empty<Energy>();

            if (_flags.HasFlag(BlueprintsFetchFlags.Workers))
            {
                workers = FetchWorkers().ToList();
            }

            if (_flags.HasFlag(BlueprintsFetchFlags.Resources))
            {
                resources = FetchResources().ToList();
            }
            
            if (_flags.HasFlag(BlueprintsFetchFlags.Components))
            {
                components = FetchComponents().ToList();
            }
            
            if (_flags.HasFlag(BlueprintsFetchFlags.Stats))
            {
                stats = FetchStats().ToList();
            }
            
            if (_flags.HasFlag(BlueprintsFetchFlags.CraftingUpgrades))
            {
                craftingUpgrades = FetchCraftingUpgrades().ToList();
            }
            
            if (_flags.HasFlag(BlueprintsFetchFlags.AscensionUpgrades))
            {
                ascensionUpgrades = FetchAscensionsUpgrades().ToList();
            }
            
            if (_flags.HasFlag(BlueprintsFetchFlags.Energy))
            {
                energy = FetchEnergy().ToList();
            }
            
            for (var i = 0; i < items.Count; i++)
            {
                yield return new Blueprint
                {
                    Item = items[i],
                    Worker = workers.Count != 0 ? workers[i] : null,
                    Resources = resources.Count != 0 ? resources[i] : null,
                    Components = components.Count != 0 ? components[i] : null,
                    Stats = stats.Count != 0 ? stats[i] : null,
                    CraftingUpgrades = craftingUpgrades.Count != 0 ? craftingUpgrades[i] : null,
                    AscensionUpgrades = ascensionUpgrades.Count != 0 ? ascensionUpgrades[i] : null,
                    Energy = energy.Count != 0 ? energy[i] : null
                };
            }
        }

        private IEnumerable<Item> FetchItem() => Fetch(SheetRanges.BlueprintsRanges.ItemRange, Item.FromRaw);
        private IEnumerable<Worker> FetchWorkers() => Fetch(SheetRanges.BlueprintsRanges.WorkersRange, Worker.FromRaw);

        private IEnumerable<Resources> FetchResources() =>
            Fetch(SheetRanges.BlueprintsRanges.ResourcesRange, Resources.FromRaw);

        private IEnumerable<Components> FetchComponents() =>
            Fetch(SheetRanges.BlueprintsRanges.ComponentsRange, Components.FromRaw);

        private IEnumerable<Stats> FetchStats() => Fetch(SheetRanges.BlueprintsRanges.StatsRange, Stats.FromRaw);

        private IEnumerable<CraftingUpgrades> FetchCraftingUpgrades() =>
            Fetch(SheetRanges.BlueprintsRanges.CraftingUpgradesRange, CraftingUpgrades.FromRaw);

        private IEnumerable<AscensionUpgrades> FetchAscensionsUpgrades() =>
            Fetch(SheetRanges.BlueprintsRanges.AscensionUpgradesRange, AscensionUpgrades.FromRaw);
        
        private IEnumerable<Energy> FetchEnergy() => Fetch(SheetRanges.BlueprintsRanges.EnergyRange, Energy.FromRaw);
        
        private IEnumerable<T> Fetch<T>(string range, Func<IList<object>, T> fromRaw)
        {
            var rawCollection = _sheetsService.FetchValueRange(range);
            
            // Skip first element, as the first element of rows are the headers
            for (var i = 1; i < rawCollection.Count; i++)
            {
                var raw = rawCollection[i];
                yield return fromRaw(raw);
            }
        }
    }
}
