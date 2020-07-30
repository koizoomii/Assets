using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public int enemycurhealth;
    public int enemymaxhealth;
    public scoremanager score;
    public GameObject enemy;
    public monsterspawn spawnpoints;
    public mememanager playerhealth;
    public mememanager timer;

    void Start()
    {
        enemycurhealth = enemymaxhealth;
        
    }

    
    void Update()
    {
        if (enemycurhealth <= 0)
        {

            enemy.gameObject.SetActive(false);

            if (gameObject.tag == "slime")
            {
                score.earnPoints(20);
            }

            if (gameObject.tag == "skeleton")
            {
                score.earnPoints(40);
            }

            if (gameObject.tag == "zombie")
            {
                score.earnPoints(60);
            }

            if (gameObject.tag == "goblin")
            {
                score.earnPoints(80);
            }

            if (gameObject.tag == "troll")
            {
                score.earnPoints(100);
            }

            Invoke("Respawn", 3);
        }

    }

    public void HurtEnemy(int amount)
    {
        enemycurhealth -= amount;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sworddamage")
        {
            enemycurhealth -= 7;
        }
    }

    public void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(enemy);
        enemyClone.transform.position = transform.position;
        enemy.gameObject.SetActive(true);
        enemycurhealth = enemymaxhealth;
    }

}
