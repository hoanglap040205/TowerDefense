using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySpawmManager : MonoBehaviour
{
    public int currentWave = 1;
    private float diffculty = 0.75f;

    public int enemyLeftToSpawm;
    public int initialEnemyAmount;

    public GameObject enemyPrefab;

    public int enemyPerSecond;
    private float timeBetweenSpawns;
    public float timeBetweenWaves;

    private bool canSpawm = false;

    public int enemyExits;

    private void Start()
    {
        timeBetweenWaves = 0;
        CaculateEnemyToSpawm();
    }

    private void Update()
    {
        SpawmEnemy();
    }

    private void CaculateEnemyToSpawm()
    {
        if (!canSpawm)
        {
            
            enemyLeftToSpawm = Mathf.RoundToInt(initialEnemyAmount * Mathf.Pow(currentWave, diffculty));
            canSpawm = true;
        }
    }

    private void SpawmEnemy()
    {
        if (canSpawm && enemyLeftToSpawm > 0)
        {
            timeBetweenSpawns -= Time.deltaTime;
            if (timeBetweenSpawns <= 0 && enemyLeftToSpawm > 0)
            {
                GameObject enemyClone = Instantiate(enemyPrefab, PathManager.instance.startPoint.position,
                    Quaternion.identity);
                Enemy enemy = enemyClone.GetComponent<Enemy>();
                enemy.OnDeath += countEnemiesDT;
                enemyExits++;
                enemyLeftToSpawm--;
                timeBetweenSpawns = 1 / enemyPerSecond;
            }
        }
        else
        {
            if (enemyExits <= 0)
            {
                timeBetweenWaves += Time.deltaTime;
            }
            if (timeBetweenWaves >= 5 && enemyExits <= 0)
            {
                canSpawm = false;
                CaculateEnemyToSpawm();
                currentWave++;
                timeBetweenWaves = 0;
            }
        }
    }

    public void countEnemiesDT()
    {
        
        enemyExits--;
    }
}