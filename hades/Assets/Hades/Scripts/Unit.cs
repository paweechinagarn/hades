using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class DieEvent : UnityEvent<Unit> { }

    public class Unit : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int health;

        public DieEvent DieEvent;

        public bool IsDead { get; private set; }

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
            Debug.Log($"{name} dies.");
            DieEvent?.Invoke(this);
        }
    }
}
