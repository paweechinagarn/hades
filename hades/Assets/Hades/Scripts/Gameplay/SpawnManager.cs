using System.Collections.Generic;
using UnityEngine;

namespace Hades
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private string[] enemyPoolNames;
        [SerializeField] private int enemyCount;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnRadius;

        private readonly List<Unit> enemies = new List<Unit>();

        public void SpawnAll()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                string name = enemyPoolNames[i % enemyPoolNames.Length];
                Spawn(name);
            }
        }

        private void Spawn(string name)
        {
            Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 0f;

            GameObject pooledObject = ObjectPoolManager.Instance.Get(name, container);
            Unit enemy = pooledObject.GetComponent<Unit>();
            if (enemy == null) return;

            enemy.transform.position = spawnPosition;
            enemy.DieEvent.AddListener(Despawn);
            enemy.Reset();
            enemies.Add(enemy);
        }

        private void Despawn(Unit enemy)
        {
            enemy.DieEvent.RemoveListener(Despawn);
            enemies.Remove(enemy);
            ObjectPoolManager.Instance.Return(enemy.gameObject);

            if (enemies.Count == 0)
            {
                SpawnAll();
            }
        }

 #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (spawnPoint == null) return;
            Gizmos.DrawWireSphere(spawnPoint.position, spawnRadius);
        }
#endif
    }
}
