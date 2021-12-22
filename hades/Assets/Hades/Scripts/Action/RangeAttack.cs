using UnityEngine;

namespace Hades
{
    public class RangeAttack : BaseAttack, IAction
    {
        [SerializeField] private string projectilePoolName;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CharacterSkill characterSkill;

        public void DoAction()
        {
            Attack();
        }

        public override void Attack()
        {
            if (IsOnCooldown) return;
            Spawn();
            StartCoroutine(Cooldown());
            Debug.Log($"{unit.name} does range attack");
        }

        public override void Hit(GameObject hitbox, Damagable damagable)
        {
            if (damagable == null || damagable.Unit == unit || damagable.Unit.IsDead || damagable.Unit.gameObject.CompareTag(unit.gameObject.tag)) return;

            Debug.Log($"{unit.name} range hits {damagable.Unit.name} with {damage} damage");
            damagable.TakeDamage(damage);
            Despawn(hitbox);
        }

        private void Spawn()
        {
            GameObject pooledObject = ObjectPoolManager.Instance.Get(projectilePoolName);
            Projectile projectile = pooledObject.GetComponent<Projectile>();
            projectile.transform.position = spawnPoint.position;
            projectile.transform.forward = unit.transform.forward;
            projectile.gameObject.SetActive(true);
            projectile.DespawnEvent.AddListener(Despawn);

            Hitbox hitbox = pooledObject.GetComponent<Hitbox>();
            hitbox.HitEvent.AddListener(Hit);
            hitbox.HitEvent.AddListener(characterSkill.ApplyEffect);
        }

        private void Despawn(GameObject pooledObject)
        {
            Projectile projectile = pooledObject.GetComponent<Projectile>();
            projectile.DespawnEvent.RemoveListener(Despawn);

            Hitbox hitbox = pooledObject.GetComponent<Hitbox>();
            hitbox.HitEvent.RemoveListener(Hit);
            hitbox.HitEvent.RemoveListener(characterSkill.ApplyEffect);

            ObjectPoolManager.Instance.Return(pooledObject);
        }
    }
}
