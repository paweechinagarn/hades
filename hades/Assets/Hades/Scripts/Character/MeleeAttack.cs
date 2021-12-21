using System.Collections;
using UnityEngine;

namespace Hades
{
    public class MeleeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Transform unit;
        [SerializeField] private GameObject hitter;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float duration;

        private Coroutine countdownCoroutine;

        private void Awake()
        {
            hitter.transform.parent = null;
            hitter.SetActive(false);
        }

        public void Attack()
        {
            hitter.transform.position = spawnPoint.position;
            hitter.transform.forward = unit.forward;
            hitter.SetActive(true);
            countdownCoroutine = StartCoroutine(Countdown());
        }

        public void Hit()
        {
            StopCoroutine(countdownCoroutine);
            hitter.SetActive(false);
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(duration);
            hitter.SetActive(false);
        }
    }
}
