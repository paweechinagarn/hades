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

        public void Hit(GameObject hitbox, Damagable damagable)
        {
            if (damagable != null) damagable.TakeDamage(damage);
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(duration);
            hitbox.SetActive(false);
        }
    }
}
