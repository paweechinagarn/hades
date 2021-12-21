using System.Collections;
using UnityEngine;

namespace Hades
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float speed;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float dashTime;

        private Vector3 forward;
        private Vector3 right;

        private bool isMoving;
        private bool isDashing;

        private void Awake()
        {
            forward = Camera.main.transform.forward;
            forward.y = 0f;
            forward.Normalize();
            right = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * forward;
        }

        public void Move(Vector3 movement)
        {
            if (movement == Vector3.zero) return;
            if (isDashing) return;

            Vector3 rightMovement = right * movement.x;
            Vector3 upMovement = forward * movement.z;
            Vector3 rotation = Vector3.Normalize(rightMovement + upMovement);

            transform.forward = rotation;
            rigidBody.MovePosition(rigidBody.position + (speed * rotation * Time.deltaTime));
        }

        public void Dash()
        {
            StartCoroutine(DashInternal());
        }

        private IEnumerator DashInternal()
        {
            isDashing = true;
            float startTime = Time.time;

            while (Time.time < startTime + dashTime)
            {
                rigidBody.MovePosition(rigidBody.position + (dashSpeed * transform.forward * Time.deltaTime));
                yield return null;
            }

            isDashing = false;
        }
    }
}
