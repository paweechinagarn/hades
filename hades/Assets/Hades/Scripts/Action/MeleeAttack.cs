using System.Collections;
using UnityEngine;

namespace Hades
{
    public class MeleeAttack : BaseAttack, IAction
    {
        [SerializeField] private GameObject hitbox;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float duration;

        private void Awake()
        {
            hitbox.transform.parent = null;
            hitbox.SetActive(false);
        }

        public void DoAction()
        {
            Attack();
        }

        public override void Attack()
        {
            if (IsOnCooldown) return;

            hitbox.transform.position = spawnPoint.position;
            hitbox.transform.forward = unit.transform.forward;
            hitbox.SetActive(true);
            StartCoroutine(CountdownHitBoxDuration());
            StartCoroutine(Cooldown());
            Debug.Log("Melee");
        }

        public override void Hit(GameObject _, Damagable damagable)
        {
            if (damagable == null || damagable.Unit == unit || damagable.Unit.IsDead) return;

            Debug.Log($"{unit.name} melee hits {damagable.Unit.name} with {damage} damage");
            damagable.TakeDamage(damage);
        }

        private IEnumerator CountdownHitBoxDuration()
        {
            yield return new WaitForSeconds(duration);
            hitbox.SetActive(false);
        }
    }
}
