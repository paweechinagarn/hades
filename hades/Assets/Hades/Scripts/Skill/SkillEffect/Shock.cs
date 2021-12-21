using System.Collections;
using UnityEngine;

namespace Hades
{
    [CreateAssetMenu(fileName = "Shock", menuName = "Hades/SkillEffect/Shock")]
    public class Shock : SkillEffect
    {
        [SerializeField] private int damage;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;

        private readonly Collider[] colliders = new Collider[10];

        public override IEnumerator Apply(Damagable damagable)
        {
            int count = Physics.OverlapSphereNonAlloc(damagable.Unit.transform.position, radius, colliders, layerMask);

            for (int i = 0; i < count; i++)
            {
                Collider collider = colliders[i];
                Damagable other = collider.GetComponent<Damagable>();

                if (other == null || other == damagable) continue;

                Debug.Log($"Shock {other.Unit.name} with {damage} damage");
                damagable.TakeDamage(damage);
            }


            yield break;
        }
    }
}
