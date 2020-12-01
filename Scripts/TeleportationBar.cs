using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TeleportationBar : MonoBehaviour
{
    private Image teleportation;
    private PlayerController player;
    private float x;
    void Start()
    {
        teleportation = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isTutorial == false)
        {
            x = player.timer;
            teleportation.fillAmount = Mathf.Lerp(teleportation.fillAmount, 2, Time.deltaTime * 0.137f);
            if (player.timer == 5)
            {
                teleportation.fillAmount = 0;
            }
        }
    }
}
