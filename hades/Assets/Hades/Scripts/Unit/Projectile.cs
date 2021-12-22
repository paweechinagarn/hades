using UnityEngine;

namespace Hades
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float duration;

        private float timer;

        private void Update()
        {
            if (timer >= duration)
            {
                Despawn();
                return;
            }

            transform.position += speed * Time.deltaTime * transform.forward;
            timer += Time.deltaTime;
        }

        private void Despawn()
        {
            Destroy(gameObject);
        }
    }
}
