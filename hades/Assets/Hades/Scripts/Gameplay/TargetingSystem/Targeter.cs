using UnityEngine;

namespace Hades
{
    public class Targeter : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        [SerializeField] private float detectRadius;
        [SerializeField] private LayerMask layerMask;

        private readonly Collider[] colliders = new Collider[10];

        public Unit Target { get; private set; }

        private void Update()
        {
            FindTarget();
        }

        public void FindTarget()
        {
            Unit newTarget = null;
            int count = Physics.OverlapSphereNonAlloc(unit.transform.position, detectRadius, colliders, layerMask);

            for (int i = 0; i < count; i++)
            {
                Collider collider = colliders[i];
                Damagable other = collider.GetComponent<Damagable>();

                if (other == null || other.Unit == unit || other.Unit.IsDead) continue;
                if (other.Unit == Target) return;

                //Debug.Log($"{unit.name} is targeting {other.Unit.name}");
                newTarget = other.Unit;
                break;
            }

            //if (newTarget == null && Target != null) Debug.Log($"{unit.name} is losing target {Target.name}");
            Target = newTarget;
        }

        public void Untarget()
        {
            Target = null;
        }
    }
}
