using UnityEngine;

namespace Hades
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 offset;

        private void Awake()
        {
            offset = transform.position;    
        }

        private void Update()
        {
            transform.position = target.position + offset;
        }
    }
}