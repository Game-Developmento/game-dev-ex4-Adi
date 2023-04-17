using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDestroyed : MonoBehaviour {

    [SerializeField] LimitedEnemySpawner spawner;

    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag) {
            spawner.SubtractEnemy();
        }
    }

    public void SetEnemySpawner(LimitedEnemySpawner spawner) {
        this.spawner = spawner;
    } 

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

}
