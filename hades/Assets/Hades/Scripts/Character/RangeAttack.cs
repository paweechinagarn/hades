using System.Collections;
using UnityEngine;

namespace Hades
{
    public class RangeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Transform unit;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform spawnPoint;

        private Coroutine countdownCoroutine;

        private void Awake()
        {
            projectile.transform.parent = null;
            projectile.SetActive(false);
        }

        public void Attack()
        {
            projectile.transform.position = spawnPoint.position;
            projectile.transform.forward = unit.forward;
            projectile.SetActive(true);
        }

        public void Hit()
        {
            StopCoroutine(countdownCoroutine);
            projectile.SetActive(false);
        }
    }
}
