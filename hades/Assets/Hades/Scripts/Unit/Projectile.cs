using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class DespawnEvent : UnityEvent<GameObject> { }

    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float duration;

        public DespawnEvent DespawnEvent;

        private float timer;

        private void Update()
        {
            if (timer >= duration)
            {
                DespawnEvent?.Invoke(gameObject);
                timer = 0f;
                return;
            }

            transform.position += speed * Time.deltaTime * transform.forward;
            timer += Time.deltaTime;
        }
    }
}
