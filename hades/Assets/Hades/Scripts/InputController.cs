using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hades
{
    [Serializable]
    public class MovementEvent : UnityEvent<Vector3> { }

    public class InputController : MonoBehaviour
    {
        public MovementEvent MovementEvent;

        private void FixedUpdate()
        {
            ProcessMovementInput();
        }

        private void ProcessMovementInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            MovementEvent?.Invoke(new Vector3(x, 0f, z));
        }
    }
}
