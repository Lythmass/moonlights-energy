using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeEsc : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject canvas;

    void Update()
    {
        if (Buttons.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseButton.SetActive(true);
                pauseMenu.SetActive(false);
                canvas.GetComponent<Canvas>().sortingOrder = -5;
                Buttons.isPaused = false;
            }
        }
    }
}
