using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedEnemySpawner : MonoBehaviour {
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;

    [SerializeField] int _num_enemies = 0;
    [SerializeField] int _enemies_limit = 1;
    
    void Start() {
         this.StartCoroutine(SpawnRoutine());    // co-routines
    }

    IEnumerator SpawnRoutine() {    // co-routines
        while (true) {
            if(_num_enemies < _enemies_limit) {
                Vector3 positionOfSpawnedObject = new Vector3(
                    transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                    transform.position.y,
                    transform.position.z);
                GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
                newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
                newObject.GetComponent<OnEnemyDestroyed>().SetEnemySpawner(this);
                ++_num_enemies;
            }
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
        }
    }

    public void SubtractEnemy() {
        --_num_enemies;
        ++_enemies_limit; // Level gets harder when an enemy is eliminated!
    }
}
