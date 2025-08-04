using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;
using Avalon.Items.Weapons.Ranged.Hardmode;// ���� ������� �������� �������
using static Terraria.ModLoader.ModContent;
using static Terraria.Localization.Language;

namespace Vanilla.Common.GlobalNPCs.Drops
{
public class MiniGolemDrops : GlobalNPC
{
public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
{
if (npc.TypeName == GetTextValue("Mods.ValhallaMod.NPCs.TempleGolem.DisplayName") || npc.FullName == GetTextValue("Mods.ValhallaMod.NPCs.TempleGolem.DisplayName"))
//������� ����� ����� if ( �� ������� �� npc.type == NPCType<MODBOSSNAME>() ���� ��� ����� �� ���������
{
npcLoot.Add(
ItemDropRule.Common(
ModContent.ItemType<SunsShadow>(),//������� ������� ��������
chanceDenominator: 10,//���� ���������, 100 / 2 = 50%
minimumDropped: 1,//���������� ��������� �������
maximumDropped: 1//���������� ��������� ��������
//���� ����� ����� �������� ������ ���������� ��������� ���������� �����
)
);
}
}
}
}
