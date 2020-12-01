using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class Buttons : MonoBehaviour
{
    public GameObject buttonMain;
    public GameObject settingsMenu;
    public GameObject badGraphics;
    public GameObject coolGraphics;
    public GameObject aboutMenu;
    public GameObject pause;
    public GameObject pauseMenu;
    public static bool grph;
    public static bool isChanged = false;
    public GameObject canvas;
    public static bool isPaused = false;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Settings()
    {
        buttonMain.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CoolGraphics()
    {
        badGraphics.SetActive(false);
        coolGraphics.SetActive(true);
        Camera.main.GetComponent<PostProcessLayer>().enabled = false;
        grph = false;
        isChanged = true;
    }
    public void BadGraphics()
    {
        coolGraphics.SetActive(false);
        badGraphics.SetActive(true);
        Camera.main.GetComponent<PostProcessLayer>().enabled = true;
        grph = true;
        isChanged = true;
    }
    public void GoBack()
    {
        settingsMenu.SetActive(false);
        buttonMain.SetActive(true);
    }
    public void About()
    {
        buttonMain.SetActive(false);
        aboutMenu.SetActive(true);
    }
    public void SecondGoBack()
    {
        aboutMenu.SetActive(false);
        buttonMain.SetActive(true);
    }
    public void Paused()
    {
        pause.SetActive(false);
        pauseMenu.SetActive(true);
        canvas.GetComponent<Canvas>().sortingOrder = 1;
        isPaused = true;
    }
    public void Resume()
    {
        pause.SetActive(true);
        pauseMenu.SetActive(false);
        canvas.GetComponent<Canvas>().sortingOrder = -5;
        isPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void TryMe()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void WinToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
