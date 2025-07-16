using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

public class FireballMadifier : GlobalProjectile
{
    public override bool InstancePerEntity => true;

    public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
    {
        if (projectile.type == ProjectileID.Fireball)
        {
            // ������ ���������� ������ ��� ������������ � �������
            projectile.Kill();
            return false; // �� ������������ ����������� ������
        }

        return base.OnTileCollide(projectile, oldVelocity);
    }
}