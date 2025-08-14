using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Quit() // buat keluar game
    {
        Application.Quit();
    }

    public void Settings() // buat nampilin scene settings
    {
        SceneManager.LoadScene("Settings");
    }

    public void Play() // buat nampilin scene gameplay
    {
        SceneManager.LoadScene("LevelChoose");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlayPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
