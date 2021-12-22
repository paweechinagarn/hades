using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class HealthEvent : UnityEvent<int, int> { }

    [Serializable]
    public class DieEvent : UnityEvent<Unit> { }

    public class Unit : MonoBehaviour
    {
        [SerializeField] private Stats stats;
        [SerializeField] private int health;

        public HealthEvent HealthEvent;
        public DieEvent DieEvent;

        public int Health
        {
            set
            {
                health = value;
                HealthEvent?.Invoke(health, stats.MaxHealth);
            }
        }
        public bool IsDead { get; private set; }

        private void Awake()
        {
            Reset();
        }

        private void Reset()
        {
            Health = stats.MaxHealth;
            IsDead = false;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;

            Health = Mathf.Max(0, health - damage);

            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            IsDead = true;
            Debug.Log($"{name} dies.");
            DieEvent?.Invoke(this);
        }
    }
}
