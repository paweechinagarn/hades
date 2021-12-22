using UnityEngine;

namespace Hades
{
    public class RangeAttack : BaseAttack, IAction
    {
        [SerializeField] private string projectilePoolName;
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
            GameObject pooledObject = ObjectPoolManager.Instance.Get(projectilePoolName);
            Projectile projectile = pooledObject.GetComponent<Projectile>();
            projectile.transform.position = spawnPoint.position;
            projectile.transform.forward = unit.transform.forward;
            projectile.gameObject.SetActive(true);
            projectile.DespawnEvent.AddListener(Despawn);
        }

        private void Despawn(GameObject hitbox)
        {
            Projectile projectile = hitbox.GetComponent<Projectile>();
            projectile.DespawnEvent.RemoveListener(Despawn);
            ObjectPoolManager.Instance.Return(hitbox);
        }
    }
}
