using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public mememanager playerhealth;
    public mememanager timer;
    public enemyHealth enemy;
    public enemyHealth enemycurhealth;
    public enemyHealth enemymaxhealth;


    public void Start()
    {
        enemy.gameObject.SetActive(false);
        InvokeRepeating("SpawnAMonster", 0f, 3f);
    }

    public void Update()
    {
        if (playerhealth.currentHealth <= 0)
        {
            enemycurhealth = enemymaxhealth;
            enemy.gameObject.SetActive(false);
        }

        if (timer.timeRemaining <= 0)
        {
            enemycurhealth = enemymaxhealth;
            enemy.gameObject.SetActive(false);
        }
    }
    public void SpawnAMonster()
    {
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        randomMonster = Random.Range(0, monsters.Length);
        Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    public void GameStart()
    {
        enemycurhealth = enemymaxhealth;
        enemy.gameObject.SetActive(true);
    }
}
