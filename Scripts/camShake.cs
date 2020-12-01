using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camShake : MonoBehaviour
{
    private int shakeNum;
    private float x;
    private float y;

    public void Shake()
    {
        shakeNum = Random.Range(2, 4);
        for (int i = 1; i <= shakeNum; i++)
        {
            x = Random.Range(-0.25f, 0.25f);
            y = Random.Range(-0.25f, 0.25f);
            transform.localPosition = new Vector2(x, y);
        }
    }
}
