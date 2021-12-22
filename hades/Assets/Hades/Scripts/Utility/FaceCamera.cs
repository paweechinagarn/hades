using UnityEngine;

namespace Hades
{
    [ExecuteInEditMode]
    public class FaceCamera : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }
}
