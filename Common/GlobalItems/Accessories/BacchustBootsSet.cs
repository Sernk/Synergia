using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace Synergia.Common.GlobalItems.Accessories
{
	public class BacchusBootsEdit : GlobalItem
	{
		public override bool AppliesToEntity(Item item, bool lateInstantiation)
		{
			return item.ModItem?.Mod?.Name == "Avalon" && item.ModItem?.Name == "BacchusBoots";
		}

		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			// ��������� +18% ����� �����������
			player.GetDamage(DamageClass.Summon) += 0.10f;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			// ������� ������ ������ � +8%
			tooltips.RemoveAll(line => line.Text.Trim() == "8% increased summon damage");

			// ��������� ����� ������
			tooltips.Add(new TooltipLine(Mod, "VanillaBuffedSummon", "+18% summon damage")
			{
				OverrideColor = Microsoft.Xna.Framework.Color.LightGoldenrodYellow
			});
		}
	}
}