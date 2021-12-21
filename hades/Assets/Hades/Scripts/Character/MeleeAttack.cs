using System.Collections;
using UnityEngine;

namespace Hades
{
    public class MeleeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Transform unit;
        [SerializeField] private GameObject hitbox;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float duration;
        [SerializeField] private int damage;

        private void Awake()
        {
            hitbox.transform.parent = null;
            hitbox.SetActive(false);
        }

        public void Attack()
        {
            hitbox.transform.position = spawnPoint.position;
            hitbox.transform.forward = unit.forward;
            hitbox.SetActive(true);
            StartCoroutine(Countdown());
        }

        public void Hit(GameObject _, Damagable damagable)
        {
            if (damagable != null)
            {
                Debug.Log($"Melee hit {damagable.Unit.name} with {damage} damage");
                damagable.TakeDamage(damage);
            }
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(duration);
            hitbox.SetActive(false);
        }
    }
}
