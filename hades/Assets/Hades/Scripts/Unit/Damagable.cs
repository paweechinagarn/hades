using UnityEngine;

namespace Hades
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private Unit unit;

        public Unit Unit => unit;

        public void TakeDamage(int damage)
        {
            unit.TakeDamage(damage);
        }
    }
}
