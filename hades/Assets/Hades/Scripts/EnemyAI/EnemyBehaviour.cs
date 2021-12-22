using UnityEngine;
using UnityEngine.AI;

namespace Hades
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private Targeter targeter;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] private float attackRange;
        [SerializeField] private Component attackableComponent;

        private IAttackable attackable;

        private void OnValidate()
        {
            if (attackableComponent == null) return;
            if (attackableComponent.GetType().IsAssignableFrom(typeof(IAttackable))) return;

            if (attackableComponent.TryGetComponent<IAttackable>(out IAttackable attackable))
            {
                attackableComponent = attackableComponent.GetComponent(attackable.GetType());
                return;
            }

            Debug.LogError($"attackableComponent must be IAttackable type");
            attackableComponent = null;
        }

        private void Awake()
        {
            attackable = attackableComponent as IAttackable;
        }

        private void FixedUpdate()
        {
            if (targeter.Target == null) return;

            Vector3 targetPosition = targeter.Target.transform.position;
            Vector3 displacement = agent.transform.position - targetPosition;

            if (Vector3.Angle(agent.transform.forward, displacement) > 0.1f)
            {
                agent.transform.LookAt(targetPosition, Vector3.up);
            }

            if (displacement.sqrMagnitude < attackRange * attackRange)
            {
                agent.isStopped = true;
                if (!attackable.IsOnCooldown) attackable.Attack();
            }
            else
            {
                agent.SetDestination(targetPosition);
                agent.isStopped = false;
            }
        }
    }
}
