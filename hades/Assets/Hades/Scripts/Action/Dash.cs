using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class DashEvent : UnityEvent<bool> { }

    public class Dash : MonoBehaviour, IAction
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private Collider characterCollider;
        [SerializeField] private GameObject hitbox;
        [SerializeField] private float speed;
        [SerializeField] private float time;

        public DashEvent DashEvent;

        private bool isDashing;
        private bool IsDashing
        {
            set
            {
                isDashing = value;
                characterCollider.enabled = !value;
                hitbox.SetActive(value);
                DashEvent?.Invoke(value);
            }
        }

        private void Awake()
        {
            hitbox.SetActive(false);
        }

        public void DoAction()
        {
            if (isDashing) return;
            StartCoroutine(DashInternal());
        }

        private IEnumerator DashInternal()
        {
            IsDashing = true;

            float startTime = Time.time;

            while (Time.time < startTime + time)
            {
                rigidBody.MovePosition(rigidBody.position + (speed * transform.forward * Time.deltaTime));
                yield return null;
            }

            IsDashing = false;
        }
    }
}
