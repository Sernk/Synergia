﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Vanilla.Content.Projectiles;

namespace Vanilla.Content.Projectiles
{
    public class PlanteraFlower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Plantera Flower");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 18000;
        }

        private int timer;

        public override void AI()
        {
            // Вращение
            Projectile.rotation += 0.05f;

            // Анимация
            if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % Main.projFrames[Projectile.type];
            }

            // Спавн волн каждые 30 тиков
            timer++;
            if (timer % 50 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 spawnPos = Projectile.Center;

                Projectile.NewProjectile(
                    Projectile.GetSource_FromAI(),
                    spawnPos,
                    Vector2.Zero,
                    ModContent.ProjectileType<PoisonDnaSeed>(),
                    20,
                    0f,
                    Main.myPlayer,
                    1f); // фаза 1

                Projectile.NewProjectile(
                    Projectile.GetSource_FromAI(),
                    spawnPos,
                    Vector2.Zero,
                    ModContent.ProjectileType<PoisonDnaSeed>(),
                    20,
                    0f,
                    Main.myPlayer,
                    -1f); // фаза 2
            }
        }
    }
}
