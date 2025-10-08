﻿using Terraria;
using Terraria.ModLoader;
using Synergia.Content.Projectiles.Reworks;

namespace Synergia.Content.Buffs
{
    public sealed class ProminenceBlessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Если у игрока есть проджи этого типа — продлеваем бафф
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ProminenceProjectile>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
