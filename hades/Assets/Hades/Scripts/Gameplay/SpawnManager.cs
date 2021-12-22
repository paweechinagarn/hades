using System.Collections.Generic;
using UnityEngine;

namespace Hades
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private Unit[] enemyPrefabs;
        [SerializeField] private int enemyCount;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnRadius;

        private readonly List<Unit> enemies = new List<Unit>();

        public void SpawnEnemy()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
                spawnPosition.y = 0f;
                Unit enemy = Instantiate(enemyPrefabs[i % enemyPrefabs.Length], container);
                enemy.transform.position = spawnPosition;
                enemy.DieEvent.AddListener(Despawn);
                enemies.Add(enemy);
            }
        }

        private void Despawn(Unit enemy)
        {
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);

            if (enemies.Count == 0)
            {
                SpawnEnemy();
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
