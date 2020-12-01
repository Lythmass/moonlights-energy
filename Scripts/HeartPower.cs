using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPower : MonoBehaviour
{
    private Moon moon;
    public GameObject effect;
    public static bool collectSound;
    private float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        moon = GameObject.FindGameObjectWithTag("Moon").GetComponent<Moon>();
    }
    private void Update()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            timer = 5;
        } else
        {
            timer -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collectSound = true;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            moon.privateHealth = 5;
        }
    }
}
