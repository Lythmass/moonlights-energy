using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private ParticleSystem ps;
    private float timer = 0;
    private void Start()
    {
        timer = 0;
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        if(timer <= 0.5f)
        {
            main.simulationSpeed = 500f;
            timer += Time.deltaTime;
        } else
        {
            main.simulationSpeed = 0.5f;
        }
    }
}
