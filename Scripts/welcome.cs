using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class welcome : MonoBehaviour
{
    public TextMeshProUGUI welcomee;
    private float timer = 10f;
    private float timer1 = 1.5f;
    private float timer2 = 10;
    private float timer3 = 1.5f;
    private float timer4 = 10f;
    private float timer5 = 1.5f;
    [HideInInspector]
    public float timer6 = 14f;
    public static bool x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.repeatTutorial == true)
        {
            welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, 0);
            z = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.repeatTutorial == true)
        {
            if (timer >= 0)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 1.5f, Time.deltaTime * 0.2f));
                timer -= Time.deltaTime;
            }
            else
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 0, Time.deltaTime * 5f));
                timer1 -= Time.deltaTime;
            }
            if (timer1 <= 0)
            {
                welcomee.text = "Press A and D to change the direction of your spaceship... but you need to accelerate first, so press Space in order to do that.";
                x = true;
            }
            else
            {
                x = false;
            }
            if (x && timer2 >= 0)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 10, Time.deltaTime * 0.5f));
                timer2 -= Time.deltaTime;
            }
            if (timer2 <= 0)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 0, Time.deltaTime * 5f));
                timer3 -= Time.deltaTime;
            }
            if (timer3 <= 0)
            {
                welcomee.text = "If you are wondering how to save the moon from the meteors, just when you seem them coming towards the moon, get close to them and crush them!";
                y = true;
            }
            else
            {
                y = false;
            }
            if (y && timer4 >= 0)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 10, Time.deltaTime));
                timer4 -= Time.deltaTime;
            }
            if (timer4 <= 0)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 0, Time.deltaTime * 5f));
            }
            if (Spawner.done)
            {
                welcomee.text = "Now you are ready to begin but before that, look at the Teleportation Bar in the top right corncer, once that bar gets full, you'll be able to teleport wherever you right click on the screen with your mouse... Let's start!";
                timer5 -= Time.deltaTime;
                timer6 -= Time.deltaTime;
            }
            if (timer5 <= 0 && z == true)
            {
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 10, Time.deltaTime * 2.5f));
            }
            if (timer6 <= 0)
            {
                z = false;
                welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 0, Time.deltaTime * 5f));
            }
            if (z == false)
            {
                PlayerController.isTutorial = false;
            }
        } else
        {
            welcomee.color = new Color(welcomee.color.r, welcomee.color.g, welcomee.color.b, Mathf.Lerp(welcomee.color.a, 0, Time.deltaTime * 1000));
        }
 
    }
}
