using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public GameObject[] snowFlake;      // prefaby duchů
    public float[] spawnWeights;        // váhy výskytu
    public GameObject[] spawn;          // spawn pointy

    float timer = 0;
    int index = 0;

    void Start()
    {
        timer = Random.Range(0, 3);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SpawnEnemy();
            timer = Random.Range(0, 4);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int enemyIndex = GetWeightedRandomIndex(spawnWeights);
        int spawnIndex = Random.Range(0, spawn.Length);

        Instantiate(snowFlake[enemyIndex], spawn[spawnIndex].transform.position, spawn[spawnIndex].transform.rotation);
    }

    // Výběr podle váhy
    private int GetWeightedRandomIndex(float[] weights)
    {
        float total = 0;
        foreach (float w in weights)
            total += w;

        float randomValue = Random.Range(0, total);
        float cumulative = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            cumulative += weights[i];
            if (randomValue < cumulative)
                return i;
        }

        return weights.Length - 1; // fallback
    }
}
