using System.Collections;
using UnityEngine;

namespace Hades
{
    public abstract class BaseAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] protected Unit unit;
        [SerializeField] protected int damage;
        [SerializeField] protected float attackSpeed;

        public bool IsOnCooldown { get; private set; }

        public abstract void Attack();

        public abstract void Hit(GameObject hitbox, Damagable damagable);

        protected IEnumerator Cooldown()
        {
            IsOnCooldown = true;
            yield return new WaitForSeconds(1f / attackSpeed);
            IsOnCooldown = false;
        }
    }
}
