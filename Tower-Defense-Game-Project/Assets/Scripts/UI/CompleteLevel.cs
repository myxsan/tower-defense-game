using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("LevelReacher", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
    
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
