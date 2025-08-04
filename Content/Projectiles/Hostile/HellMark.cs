﻿using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using System;

namespace Vanilla.Content.Projectiles.Hostile
{
    public class HellMark : ModProjectile
    {
        private const int FrameCount = 5;
        private const int HoverTime = 60;
        private const float HoverOffset = 80f;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hell Mark");
            Main.projFrames[Projectile.type] = FrameCount; // 5 
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hostile = false;
            Projectile.friendly = false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];


            if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= FrameCount)
                    Projectile.frame = 0;
            }

            if (Projectile.ai[0] < HoverTime)
            {
                Vector2 hoverPos = player.Center - new Vector2(0, HoverOffset + (float)Math.Sin(Main.GameUpdateCount / 10f) * 10f);
                Projectile.Center = Vector2.Lerp(Projectile.Center, hoverPos, 0.1f);
                Projectile.rotation = 0;
                Projectile.ai[0]++;
            }
            else
            {

                if (Projectile.velocity == Vector2.Zero)
                    Projectile.velocity = new Vector2(0, -14f);

                Projectile.rotation += 0.2f;
            }

            Lighting.AddLight(Projectile.Center, Color.Red.ToVector3() * 1.3f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
            Rectangle frame = texture.Frame(1, FrameCount, 0, Projectile.frame);
            Vector2 origin = frame.Size() / 2f;

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, frame, Color.White,
                Projectile.rotation, origin, 1f, SpriteEffects.None, 0f);

            return false;
        }
    }
}