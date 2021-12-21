using UnityEngine;

namespace Hades
{
    public class RangeAttack : MonoBehaviour, IAction, IAttackable
    {
        [SerializeField] private Transform unit;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int damage;

        public void DoAction()
        {
            Attack();
        }

        public void Attack()
        {
            Spawn();
        }

        public void Hit(GameObject hitbox, Damagable damagable)
        {
            if (damagable != null)
            {
                Debug.Log($"Range hit {damagable.Unit.name} with {damage} damage");
                damagable.TakeDamage(damage);
            }

            Despawn(hitbox);
        }

        private void Spawn()
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = spawnPoint.position;
            projectile.transform.forward = unit.forward;
            projectile.SetActive(true);
        }

        private void Despawn(GameObject projectile)
        {
            Destroy(projectile);
        }
    }
}
