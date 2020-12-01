using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleSpawner : MonoBehaviour
{
    private float x;
    private float y;
    private float timer;
    public float startTimer;
    public GameObject scalePowerUp;
    public GameObject effect;
    private void Start()
    {
        timer = startTimer;
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isTutorial == false)
        {
            if (timer <= 0)
            {
                x = Random.Range(-11, 11);
                y = Random.Range(-6.2f, 6.2f);
                Vector2 spawnPos = new Vector2(x, y);
                Instantiate(scalePowerUp, spawnPos, Quaternion.identity);
                Instantiate(effect, spawnPos, Quaternion.identity);
                timer = startTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
