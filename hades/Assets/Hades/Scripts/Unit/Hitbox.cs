using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class HitEvent : UnityEvent<GameObject, Damagable> { }

    public class Hitbox : MonoBehaviour
    {
        public HitEvent HitEvent;

        private void OnTriggerEnter(Collider other)
        {
            Damagable damagable = other.GetComponent<Damagable>();
            HitEvent?.Invoke(gameObject, damagable);
        }
    }
}
