using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;

namespace Vanilla.Common.GlobalItems.Set
{
    public class OstaraEdit : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem != null && item.ModItem.Mod.Name == "Consolaria")
            {
                switch (item.Name)
                {
                    case "Hat of Ostara":
                        ReplaceTooltip(tooltips, "Tooltip0", "11% Increased throwing damage and crit chance by 5%");
                        break;

                    case "Jacket of Ostara":
                        ReplaceTooltip(tooltips, "Tooltip0", "Throwing speed increased by 13% ");
                        break;

                    case "Boots of Ostara":
                        ReplaceTooltip(tooltips, "Tooltip0", "Jump height increased");
                        break;
                }
            }
        }

        private void ReplaceTooltip(List<TooltipLine> tooltips, string tooltipName, string newText)
        {
            for (int i = 0; i < tooltips.Count; i++)
            {
                if (tooltips[i].Name == tooltipName && tooltips[i].Mod == "Terraria")
                {
                    tooltips[i].Text = newText;
                    break;
                }
            }
        }
    }
}