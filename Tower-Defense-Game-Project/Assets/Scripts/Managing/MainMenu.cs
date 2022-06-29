using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo("MainLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
