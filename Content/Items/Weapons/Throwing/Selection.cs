using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Synergia.Content.Projectiles.Friendly;

namespace Synergia.Content.Items.Weapons.Throwing
{
	public class Selection : ModItem
	{
		public override void SetDefaults()
		{
			var item = Item;

			item.damage = 40;
			item.DamageType = DamageClass.Throwing;
			item.width = 24;
			item.height = 25;
			item.useTime = 10;
			item.useAnimation = 10;
			item.knockBack = 2;
			item.value = Item.buyPrice(silver: 50);
			item.shootSpeed = 14f;
			item.maxStack = 1;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.useStyle = ItemUseStyleID.Swing;
			item.shoot = ModContent.ProjectileType<SelectionProjectile>();
			item.consumable = false;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.noMelee = true;
		}
	}
}
