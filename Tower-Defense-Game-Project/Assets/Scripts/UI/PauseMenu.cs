using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    private void Start() {
        if(UI.activeSelf) UI.SetActive(false);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if(UI.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
       // Toggle();
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
      //  Toggle();
        Time.timeScale = 1;
        sceneFader.FadeTo(menuSceneName);
    }
}
