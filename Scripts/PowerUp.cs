using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;
    public static bool isCollected;
    public static bool sound;
    private float timer = 5;
    public GameObject effect;
    public GameObject effectByPlayer;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        if (timer <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            timer = 5;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(effectByPlayer, transform.position, Quaternion.identity);
            Destroy(gameObject);
            isCollected = true;
            sound = true;
        }
    }
}
