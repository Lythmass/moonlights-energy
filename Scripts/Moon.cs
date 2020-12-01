using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moon : MonoBehaviour
{
    public float speed;
    public float health;
    [HideInInspector]
    public float privateHealth;
    private SpriteRenderer cracks;
    public Sprite moon1;
    public Sprite moon2;
    public Sprite moon3;
    public Sprite moon4;
    public Sprite moon5;
    public Sprite moon0;
    private float timer = 2f;
    public GameObject effect;
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool death;
    public AudioSource explode;
    // Start is called before the first frame update
    void Start()
    {
        privateHealth = health;
        cracks = GetComponent<SpriteRenderer>();
        isDead = false;
        death = false;
        explode.volume = volume.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(volume.isChanged == false)
        {
            explode.volume = 1;
        } else
        {
            explode.volume = volume.x;
        }
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        if (PlayerController.isTutorial == false)
        {
            if (privateHealth == 5)
            {
                cracks.sprite = moon0;
                isDead = false;
                death = false;
            }
            if (privateHealth == 4)
            {
                cracks.sprite = moon1;
                isDead = false;
                death = false;
            }
            if (privateHealth == 3)
            {
                cracks.sprite = moon2;
                isDead = false;
                death = false;
            }
            if (privateHealth == 2)
            {
                cracks.sprite = moon3;
                isDead = false;
                death = false;
            }
            if (privateHealth == 1)
            {
                cracks.sprite = moon4;
                isDead = false;
                death = false;
            }
            if (privateHealth == 0)
            {
                cracks.sprite = moon5;
                isDead = true;
                death = false;
            }
            if (privateHealth <= -1)
            {
                isDead = true;
                death = true;
                cracks.enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Meteorite"))
        {
            explode.Play();
        }
    }
}
