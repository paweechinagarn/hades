using UnityEngine;

namespace Hades
{
    public interface IAttack
    {
        void Attack();
        void Hit(GameObject hitbox, Damagable damagable);
    }
}
