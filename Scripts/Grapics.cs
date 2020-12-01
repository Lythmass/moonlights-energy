using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Grapics : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (Buttons.isChanged == true)
        {
            if (Buttons.grph)
            {
                Camera.main.GetComponent<PostProcessLayer>().enabled = true;
            }
            if (Buttons.grph == false)
            {
                Camera.main.GetComponent<PostProcessLayer>().enabled = false;
            }
        }
        if (volume.isChanged)
        {
            music.volume = volume.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
