using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public static float speed = 2.5f;
    private Moon moon;
    public GameObject effect;
    public static bool isHit;
    private camShake shake;
    private PlayerController player;
    private float timer = 2f;
    public GameObject moonEffect;
    public AudioSource sound;
    private AudioSource music;
    public static bool musika = true;
    void Start()
    {
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Moon>();
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<camShake>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }
    void Update()
    {
        sound.volume = volume.x;
        if (Buttons.isPaused)
        {
            sound.enabled = false;
        } else
        {
            sound.enabled = true;
        }
        if (moon.death == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, moon.transform.position, speed * Time.deltaTime);
        }
        if (moon.death)
        {
            musika = true;
            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                musika = false;
            } else
            {
                timer -= Time.deltaTime;
                music.volume = Mathf.Lerp(music.volume, 0, Time.deltaTime * 5f);
            }
        }
        if (Spawner.done && PlayerController.isTutorial == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Moon"))
        {
            Destroy(gameObject);
            if (PlayerController.isTutorial == false)
            {
                moon.privateHealth--;
                PlayerController.killCount++;
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            isHit = true;
            if (moon.isDead)
            {
                sound.Play();
                Instantiate(moonEffect, moon.transform.position, Quaternion.identity);
            }
        }
    }
}
