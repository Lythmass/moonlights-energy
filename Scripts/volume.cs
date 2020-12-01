using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public AudioSource music;
    public static float x;
    public static bool isChanged = false;

    // Start is called before the first frame update
    public void ChangeSound()
    {
        music.volume = gameObject.GetComponent<Slider>().value;
        x = music.volume;
        isChanged = true;
    }
}
