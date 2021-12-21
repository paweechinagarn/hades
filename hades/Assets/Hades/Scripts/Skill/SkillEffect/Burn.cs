using System.Collections;
using UnityEngine;

namespace Hades
{
    [CreateAssetMenu(fileName ="Burn", menuName = "Hades/SkillEffect/Burn")]
    public class Burn : SkillEffect
    {
        [SerializeField] private int damageOverTime;
        [SerializeField] private float duration;

        private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(1f);

        public override IEnumerator Apply(Damagable damagable)
        {
            float startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                if (damagable.IsDead) yield break;

                Debug.Log($"Burn {damagable.Unit.name} with {damageOverTime} damage");
                damagable.TakeDamage(damageOverTime);
                yield return waitForSeconds;
            }
        }
    }
}
