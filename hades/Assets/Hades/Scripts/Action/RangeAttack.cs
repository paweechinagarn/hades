using UnityEngine;

namespace Hades
{
    public class RangeAttack : BaseAttack, IAction
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;

        public void DoAction()
        {
            Attack();
        }

        public override void Attack()
        {
            if (IsOnCooldown) return;
            Spawn();
        }

        public override void Hit(GameObject hitbox, Damagable damagable)
        {
            Despawn(hitbox);

            if (damagable == null || damagable.Unit == unit || damagable.Unit.IsDead) return;

            Debug.Log($"{unit.name} range hits {damagable.Unit.name} with {damage} damage");
            damagable.TakeDamage(damage);
        }

        private void Spawn()
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = spawnPoint.position;
            projectile.transform.forward = unit.transform.forward;
            projectile.SetActive(true);
        }

        private void Despawn(GameObject projectile)
        {
            Destroy(projectile);
        }
    }
}
