﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{

    public List<GameObject> heartPrefabs = new List<GameObject>();
    public float healthDropProbability;
    public int xzRange = 600;
    public int yForce = 800;
    public float spawnHeight = 2.5f;

    private void Awake()
    {
        SubscribeToEnemyDeath();
    }

    void SubscribeToEnemyDeath()
    {
        Enemy enemy = transform.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.deathEvent += DropHeart;
        }
    }

    /* Called when an enemy has died. Spawns a heart with random probability.
    */
    public void DropHeart(GameObject enemy)
    {
        var heartTypeChance = (int)Mathf.Round(Random.Range(0f, heartPrefabs.Count - 1));
        var heartType = heartPrefabs[heartTypeChance];

        var chance = Random.value;
        if (chance <= healthDropProbability)
        {
            var randX = Random.Range(-xzRange, xzRange);
            var randZ = Random.Range(-xzRange, xzRange);
            var heart = Instantiate(heartType, transform.position + new Vector3(0, spawnHeight, 0), heartType.transform.rotation);

            var heartRb = heart.GetComponent<Rigidbody>();

            heartRb.AddForce(new Vector3(randX, yForce, randZ));
        }
    }
}