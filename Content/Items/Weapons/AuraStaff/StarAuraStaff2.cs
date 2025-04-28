using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Vanilla.Content.Projectiles.Aura;
using static Terraria.ModLoader.ModContent;

namespace Vanilla.Content.Items.Weapons.AuraStaff
{
	[ExtendsFromMod("ValhallaMod")]
	public class StarAuraStaff2 : ValhallaMod.Items.AI.ValhallaAuraItem
	{
		public override void SetDefaults()
		{
			var item = Item;

			item.DamageType = DamageClass.Summon;
			item.width = 38;
			item.height = 38;
			item.useTime = 30;
			item.useAnimation = 30;
			item.UseSound = SoundID.Item82;
			item.noMelee = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.Shoot;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.mana = 20;
			item.damage = 24;
			item.shoot = ProjectileType<StarAura2>();
			item.shootSpeed = 1f;
		}
	}
}