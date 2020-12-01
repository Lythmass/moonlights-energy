using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEsc : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
            Buttons.isPaused = true;
            canvas.GetComponent<Canvas>().sortingOrder = 1;
        }
    }
}
