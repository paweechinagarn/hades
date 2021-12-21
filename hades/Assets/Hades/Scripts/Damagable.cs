using UnityEngine;

namespace Hades
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private GameObject unit;
        [SerializeField] private int maxHealth;
        [SerializeField] private int health;
        
        public bool IsDead { get; private set; }

        public GameObject Unit => unit;

        private void Awake()
        {
            Reset();
        }

        private void Reset()
        {
            health = maxHealth;
            IsDead = false;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;

            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            IsDead = true;
            Debug.Log($"{unit.name} dies.");
            Despawn();
        }

        private void Despawn()
        {
            Destroy(unit);
        }
    }
}
