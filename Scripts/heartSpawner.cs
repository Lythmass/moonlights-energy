using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartSpawner : MonoBehaviour
{
    private float x;
    private float y;
    private float privateTimer;
    public float timer;
    public GameObject heart;
    public GameObject spawnEffect;
    private void Start()
    {
        privateTimer = timer;
    }
    void Update()
    {
        if (PlayerController.isTutorial == false)
        {
            if (privateTimer <= 0)
            {
                x = Random.Range(-11, 11);
                y = Random.Range(-6.2f, 6.2f);
                Vector2 spawnPos = new Vector2(x, y);
                Instantiate(spawnEffect, spawnPos, Quaternion.identity);
                Instantiate(heart, spawnPos, Quaternion.identity);
                privateTimer = timer;
            }
            else
            {
                privateTimer -= Time.deltaTime;
            }
        }
    }
}
