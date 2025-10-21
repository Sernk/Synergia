﻿using MonoMod.RuntimeDetour;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using ValhallaMod.Items.Accessory;
using ValhallaMod.Items.Placeable.Brazier;
using ValhallaMod.Items.Weapons.Aura;
using ValhallaMod.Items.Weapons.Dart;
using ValhallaMod.NPCs.TownNPCs;

namespace Synergia.Common.ModSystems.Hooks
{
    public class DwarfShopChanges : ModSystem
    {
        private Hook _GetSetShoop;

        public override void Load()
        {
            MethodInfo target = typeof(Dwarf).GetMethod(nameof(Dwarf.AddShops), BindingFlags.Instance | BindingFlags.Public);
            _GetSetShoop = new Hook(target, (GetSetShoop)NewDwarfShoop);
        }
        public override void Unload()
        {
            _GetSetShoop?.Dispose();
            _GetSetShoop = null;
        }

        private delegate void Orig_SetShoop(Dwarf npc);
        private delegate void GetSetShoop(Orig_SetShoop orig, Dwarf npc);

        private void NewDwarfShoop(Orig_SetShoop orig, Dwarf npc) // npc одно и тоже что и в классe ModNPC
        {
            new NPCShop(npc.Type).Add<BerserkNeck>([])
            .Add<FrostburnAuraStaff>([Condition.DownedEyeOfCthulhu])
            .Add<IceBrazier>([Condition.DownedEyeOfCthulhu])
            .Add(new Item(988) { shopCustomPrice = 10 })
            .Add(new Item(ModContent.ItemType<FrostburnDart>()) { shopCustomPrice = 10 })
            .Register();
        }
    }
}