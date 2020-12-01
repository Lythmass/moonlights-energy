using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{
    private float x;
    private float y;
    Vector2 spawnPos;
    Vector2 spawnPos1;
    Vector2 spawnPos2;
    Vector2 spawnPos3;
    private float timer;
    public float firstWaveTimer;
    public GameObject projectile;
    private int count;
    public int maxNumber;
    private int waves;
    public TextMeshProUGUI wavesText;
    public float secondWaveTimer;
    public float thirdWaveTimer;
    public float fourthWaveTimer;
    public float fifthWaveTimer;
    public float sixthWaveTimer;
    public float seventhWaveTimer;
    public float eighthWaveTimer;
    public float ninthWaveTimer;
    public float tenthWaveTimer;
    private float timer1 = 5f;
    private float tutTimer = 32f;
    private float tutX;
    public static bool done = false;
    private bool start = false;
    private bool repeat = true;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.isTutorial == false)
        {
            timer = firstWaveTimer;
        }
        waves = 0;
        wavesText.text = "Wave " + waves.ToString() + "/10";
        PlayerController.killCount = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isTutorial)
        {
            tutX = Random.Range(-13, 13);

            if (PlayerController.isTutorial && tutTimer <= 0 && PlayerController.tutKillCount < 3 && done == false)
            {
                Projectile.speed = 0.75f;
                Vector2 tutorialSpawn = new Vector2(tutX, 8);
                Instantiate(projectile, tutorialSpawn, Quaternion.identity);
                tutTimer = 2.5f;
            }
            if (tutTimer > 0)
            {
                tutTimer -= Time.deltaTime;
            }
            if (PlayerController.tutKillCount >= 3)
            {
                done = true;
            }
        }
        if (PlayerController.isTutorial == false)
        {
            if (start) 
            {
                waves = 1;
                wavesText.text = "Wave " + waves.ToString() + "/10";
                timer = firstWaveTimer;
                start = false;
            }
            if (timer <= 0 && count <= maxNumber)
            {
                x = Random.Range(-15, 15);
                y = Random.Range(-8, 8);
                spawnPos = new Vector2(x, 8);
                spawnPos1 = new Vector2(x, -8);
                spawnPos2 = new Vector2(15, y);
                spawnPos3 = new Vector2(-15, y);
                int rand = Random.Range(1, 5);
                if (rand == 1)
                {
                    Instantiate(projectile, spawnPos, Quaternion.identity);
                    count++;
                }
                else if (rand == 2)
                {
                    Instantiate(projectile, spawnPos1, Quaternion.identity);
                    count++;
                }
                else if (rand == 3)
                {
                    Instantiate(projectile, spawnPos2, Quaternion.identity);
                    count++;
                }
                else if (rand == 4)
                {
                    Instantiate(projectile, spawnPos3, Quaternion.identity);
                    count++;
                }
                if (waves == 1)
                {
                    timer = firstWaveTimer;
                }
                if (waves == 2)
                {
                    timer = secondWaveTimer;
                }
                if (waves == 3)
                {
                    timer = thirdWaveTimer;
                }
                if (waves == 4)
                {
                    timer = fourthWaveTimer;
                }
                if (waves == 5)
                {
                    timer = fifthWaveTimer;
                }
                if (waves == 6)
                {
                    timer = sixthWaveTimer;
                }
                if (waves == 7)
                {
                    timer = seventhWaveTimer;
                }
                if (waves == 8)
                {
                    timer = eighthWaveTimer;
                }
                if (waves == 9)
                {
                    timer = ninthWaveTimer;
                }
                if (waves == 10)
                {
                    timer = tenthWaveTimer;
                }
            }
            else
            {
                if (repeat)
                {
                    start = true;
                    repeat = false;
                }
                timer -= Time.deltaTime;
            }
            if (PlayerController.killCount >= 10 && waves == 1)
            {
                firstWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < 10 && waves == 1)
            {
                Projectile.speed = 2.5f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 2)
            {
                secondWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 2)
            {
                Projectile.speed = 2.75f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 3)
            {
                thirdWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 3)
            {
                Projectile.speed = 3;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 4)
            {
                fourthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 4)
            {
                Projectile.speed = 3.25f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 5)
            {
                fifthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 5)
            {
                Projectile.speed = 3.5f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 6)
            {
                sixthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 6)
            {
                Projectile.speed = 3.75f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 7)
            {
                seventhWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 7)
            {
                Projectile.speed = 4f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 8)
            {
                eighthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 8)
            {
                Projectile.speed = 4.25f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 9)
            {
                ninthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 9)
            {
                Projectile.speed = 4.5f;
            }
            if (PlayerController.killCount >= maxNumber / 2 && waves == 10)
            {
                tenthWaveTimer = 0.01f;
                Projectile.speed = 0.5f;
            }
            else if (PlayerController.killCount < maxNumber / 2 && waves == 10)
            {
                Projectile.speed = 4.75f;
            }
            if (PlayerController.killCount >= maxNumber)
            {
                if (timer1 <= 0)
                {
                    PlayerController.killCount = 0;
                    count = 0;
                    maxNumber += 2;
                    waves += 1;
                    wavesText.text = "Wave " + waves.ToString() + "/10";
                    timer1 = 5f;
                }
                else
                {
                    timer1 -= Time.deltaTime;
                }
            }
            if (waves > 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    
    }
}
