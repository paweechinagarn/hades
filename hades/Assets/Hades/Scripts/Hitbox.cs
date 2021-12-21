using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    public class Hitbox : MonoBehaviour
    {
        public UnityEvent HitEvent;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit");
            HitEvent?.Invoke();
        }
    }
}
