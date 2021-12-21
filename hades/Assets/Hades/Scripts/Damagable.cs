using UnityEngine;

namespace Hades
{
    public class Damagable : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int health;
        
        private bool isDead;

        private void Awake()
        {
            Reset();
        }

        private void Reset()
        {
            health = maxHealth;
            isDead = false;
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            isDead = true;
            Debug.Log($"{name} dies.");
            Despawn();
        }

        private void Despawn()
        {
            Destroy(gameObject);
        }
    }
}
