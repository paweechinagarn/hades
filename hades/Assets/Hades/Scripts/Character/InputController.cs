using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Hades
{
    [Serializable]
    public class MovementEvent : UnityEvent<Vector3> { }

    public class InputController : MonoBehaviour
    {
        public MovementEvent MovementEvent;
        public UnityEvent MeleeActionEvent;
        public UnityEvent RangeActionEvent;
        public UnityEvent DashActionEvent;

        private void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            ProcessMovementInput();
            ProcessActionInput();
        }

        private void ProcessMovementInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            MovementEvent?.Invoke(new Vector3(x, 0f, z));
        }
        
        private void ProcessActionInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Melee");
                MeleeActionEvent?.Invoke();
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Range");
                RangeActionEvent?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Dash");
                DashActionEvent?.Invoke();
            }
        }
    }
}
