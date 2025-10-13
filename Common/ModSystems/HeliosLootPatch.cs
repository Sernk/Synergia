﻿using Bismuth.Utilities.Global;
using Bismuth.Utilities;
using MonoMod.RuntimeDetour;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Synergia.Content.Items.Misc;

namespace Synergia.Common.ModSystems
{
    public class HeliosLootPatch : ModSystem
    {
        Hook NewItemHook;
        public override void Load()
        {
            MethodInfo target = typeof(Skeletron).GetMethod(nameof(Skeletron.GenerateBiomeHeliosChestLoot), BindingFlags.Instance | BindingFlags.Public);
            NewItemHook = new Hook(target, (New_GenerateBiomeHeliosChestLoot)NewLootInChest);
        }
        public override void Unload()
        {
            NewItemHook?.Dispose();
            NewItemHook = null;
        }
        private delegate void Orig_GenerateBiomeHeliosChestLoot(Skeletron skeletron, Item[] items, int Item);
        private delegate void New_GenerateBiomeHeliosChestLoot(Orig_GenerateBiomeHeliosChestLoot orig, Skeletron skeletron, Item[] items, int Item);
        private void NewLootInChest(Orig_GenerateBiomeHeliosChestLoot orig, Skeletron skeletron, Item[] items, int Item)
        {
            orig(skeletron, items, Item);
            items[Item + 7].SetDefaults(ModContent.ItemType<HeliosSoul>()); Item++;
        }
    }
}