using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

public class AcceleratingFireball : GlobalProjectile
{
    public override bool InstancePerEntity => true;

    public override void AI(Projectile projectile)
    {
        if (projectile.type == ProjectileID.Fireball)
        {
            // ����������� ������
            projectile.localAI[0]++;

            // ������� ��������� � ������� ������ 60 ����� (1 �������)
            if (projectile.localAI[0] <= 60f)
            {
                projectile.velocity *= 1.03f; // ������� ���������� ��������
            }
        }
    }
}