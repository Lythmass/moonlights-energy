using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayVolume : MonoBehaviour
{
    private void Start()
    {
        if (volume.isChanged)
        {
            gameObject.GetComponent<Slider>().value = volume.x;
        } else
        {
            gameObject.GetComponent<Slider>().value = 1;
        }
    }

}
