using UnityEngine;

namespace Hades
{
    public interface IAttackable
    {
        bool IsOnCooldown { get; }
        void Attack();
        void Hit(GameObject hitbox, Damagable damagable);
    }
}
