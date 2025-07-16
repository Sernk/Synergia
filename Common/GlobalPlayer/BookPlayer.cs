using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static Terraria.Localization.Language;

namespace Vanilla.Common.GlobalPlayer
{
	public class BookPlayer : ModPlayer
	{
		private static Mod avalon = ModLoader.GetMod("Avalon");
		private static Mod vanilla = ModLoader.GetMod("Vanilla");
		private static Mod consolaria = ModLoader.GetMod("Consolaria");
		private static Mod roa = ModLoader.GetMod("RoA");
		public bool BookVisible = false;
		public float BookOpacity = 0f; // ��������� ������������

		public override void PostUpdate()
		{
			// ������� ���������� ��� ���������� ������������
			float targetOpacity = BookVisible ? 1f : 0f;
			float opacitySpeed = 0.1f; // �������� ���������/������������ (������ ������)

			BookOpacity = MathHelper.Lerp(BookOpacity, targetOpacity, opacitySpeed);
		}

		public void DrawBook(SpriteBatch spriteBatch)
		{
			if (BookOpacity > 0.01f)
			{
				Texture2D texture = ModContent.Request<Texture2D>("Vanilla/Assets/UIs/AncientBook").Value;

				// ����� ������
				Vector2 position = new Vector2(Main.screenWidth, Main.screenHeight) / 2f;
				Vector2 origin = new Vector2(texture.Width, texture.Height) / 2f;

				spriteBatch.Draw(
					texture,
					position,
					null,
					Color.White * BookOpacity,
					0f,
					origin,
					1f, // ������� 1:1
					SpriteEffects.None,
					0f
				);

				Point mousePos = Main.MouseScreen.ToPoint();

				// 1. ����
				Rectangle GelZone = new Rectangle((int)(position.X - 220), (int)(position.Y - 315), 20, 20);

				if (GelZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.Gel).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 2. ������
				Rectangle CrownZone = new Rectangle((int)(position.X - 190), (int)(position.Y - 315), 20, 20);

				if (CrownZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.GoldCrown).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 3. ������ �� �������
				Rectangle IckyZone = new Rectangle((int)(position.X - 207), (int)(position.Y - 288), 26, 20);

				if (IckyZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("IckyAltar").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 4. ������� ������ �������
				Rectangle KingSlimeZone = new Rectangle((int)(position.X - 150), (int)(position.Y - 300), 140, 60);

				if (KingSlimeZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("KingSlimeHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 5. ������ ������
				Rectangle SlimeCrownZone = new Rectangle((int)(position.X - 208), (int)(position.Y - 265), 20, 20);

				if (SlimeCrownZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.SlimeCrown).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 6. ����
				Rectangle EggZone = new Rectangle((int)(position.X - 208), (int)(position.Y - 210), 20, 25);

				if (EggZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(consolaria.Find<ModItem>("SuspiciousLookingEgg").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 7. ������� ������
				Rectangle LepusZone = new Rectangle((int)(position.X - 150), (int)(position.Y - 215), 140, 45);

				if (LepusZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("LepusHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 8. �����
				Rectangle LensZone = new Rectangle((int)(position.X - 208), (int)(position.Y - 155), 20, 25);

				if (LensZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.Lens).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 9. ������ �� ������� 2
				Rectangle IckyZone2 = new Rectangle((int)(position.X - 207), (int)(position.Y - 122), 26, 20);

				if (IckyZone2.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("IckyAltar").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 10. ������������� ���������� ����
				Rectangle EyeZone = new Rectangle((int)(position.X - 206), (int)(position.Y - 100), 25, 20);

				if (EyeZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.SuspiciousLookingEye).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 11. ������� �����
				Rectangle EyeBossZone = new Rectangle((int)(position.X - 140), (int)(position.Y - 145), 115, 70);

				if (EyeBossZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("EyeHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 12. Virulent Powder
				Rectangle PowderZone = new Rectangle((int)(position.X - 220), (int)(position.Y - 65), 20, 20);

				if (PowderZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("VirulentPowder").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 13. Yucky Bit
				Rectangle BitZone = new Rectangle((int)(position.X - 190), (int)(position.Y - 65), 20, 20);

				if (BitZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("YuckyBit").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 14. ������ �� ������� 3
				Rectangle IckyZone3 = new Rectangle((int)(position.X - 207), (int)(position.Y - 40), 26, 20);

				if (IckyZone3.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("IckyAltar").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 15. Infested Carcass
				Rectangle CarcassZone = new Rectangle((int)(position.X - 208), (int)(position.Y - 10), 20, 24);

				if (CarcassZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(avalon.Find<ModItem>("InfestedCarcass").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 16. ������� ����������
				Rectangle BacteriumZone = new Rectangle((int)(position.X - 135), (int)(position.Y - 55), 115, 50);

				if (BacteriumZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("BacteriumHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 17. ������
				Rectangle BeeZone = new Rectangle((int)(position.X - 208), (int)(position.Y - -40), 20, 25);

				if (BeeZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(ItemID.Abeemination).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 17. ������� �����
				Rectangle BeeBossZone = new Rectangle((int)(position.X - 135), (int)(position.Y - -30), 120, 50);

				if (BeeBossZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("BeeHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 18. ����
				Rectangle FeatherZone = new Rectangle((int)(position.X - 220), (int)(position.Y - -120), 20, 25);

				if (FeatherZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(consolaria.Find<ModItem>("TurkeyFeather").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 19. �������
				Rectangle StuffingZone = new Rectangle((int)(position.X - 190), (int)(position.Y - -120), 20, 25);

				if (StuffingZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(consolaria.Find<ModItem>("CursedStuffing").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 20. ������� �������
				Rectangle TurkorZone = new Rectangle((int)(position.X - 135), (int)(position.Y - -120), 120, 30);

				if (TurkorZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("TurkorHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}

				// 21. ������� ��������
				Rectangle GoblinZone = new Rectangle((int)(position.X - 275), (int)(position.Y - -205), 215, 80);

				if (GoblinZone.Contains(mousePos))
				{
					Main.HoverItem = new Item(vanilla.Find<ModItem>("GoblinHistory").Type).Clone();
					Main.instance.MouseText(Main.HoverItem.Name, Main.HoverItem.rare, 0);
					return;
				}
			}
		}
	}
}
