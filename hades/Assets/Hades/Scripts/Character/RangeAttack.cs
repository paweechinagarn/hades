using UnityEngine;

namespace Hades
{
    public class RangeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Transform unit;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int damage;

        public void Attack()
        {
            Spawn();
        }

        public void Hit(GameObject hitbox, Damagable damagable)
        {
            if (damagable != null) damagable.TakeDamage(damage);
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
