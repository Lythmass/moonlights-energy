using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private camShake shake;
    private float timer = 0.25f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<camShake>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Projectile.isHit == true)
        {
            timer -= Time.deltaTime;
            if (timer >= 0)
            {
                shake.Shake();
            } else
            {
                Projectile.isHit = false;
                shake.transform.localPosition = new Vector2(0, 0);
            }
        } else
        {
            timer = 0.25f;
        }
        if(PlayerController.isTeleported)
        {
            anim.SetTrigger("Shake");
            PlayerController.isTeleported = false;
        }
    }
}
