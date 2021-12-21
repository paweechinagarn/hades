using UnityEngine;

namespace Hades
{
    public interface IAttackable
    {
        void Attack();
        void Hit(GameObject hitbox, Damagable damagable);
    }
}
