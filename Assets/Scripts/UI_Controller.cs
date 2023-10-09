using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class UI_Controller : MonoBehaviour
{
    public FishCollectorController collector;
    public TextMeshProUGUI text;
    public GameObject pauseMenuUI;

    public static bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = "Score: " + collector.GetFishScore(); 
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Continues game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }

    //Pauses game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

    //Exits current game to main menu
    public void QuitToMenu()
    {
        /*
         * To make sure this code works first we need to create a MainMenu scene
         * Then we need to navigate to File > Build Settings
         * Then make sure in Build Settings that MainMenu is included in the "Scenes in Build'
         * Then Load's the scene based on it's variable in the Build Settings. 
         */
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    //Closes the Application
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}