using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySound : MonoBehaviour
{
    public AudioSource audioo;
    // Start is called before the first frame update
    void Start()
    {
        audioo.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Buttons.isPaused)
        {
            audioo.volume = 0;
        }
        if(PlayerController.isFlying)
        {
            if (volume.isChanged)
            {
                audioo.volume = Mathf.Lerp(audioo.volume, volume.x, Time.deltaTime * 5);
            } 
            if(volume.isChanged == false)
            {
                audioo.volume = Mathf.Lerp(audioo.volume, 1,Time.deltaTime * 5);
            }

        } else
        {
            audioo.volume = Mathf.Lerp(audioo.volume, 0, Time.deltaTime * 5);
        }
    }
}
