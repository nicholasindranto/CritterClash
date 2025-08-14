using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void Level1Pressed()
    {
        LevelManager.Instance.level = 1; // set levelnya
        SceneManager.LoadScene("Gameplay"); // masuk ke scenenya
    }

    public void Level2Pressed()
    {
        LevelManager.Instance.level = 2;
        SceneManager.LoadScene("Gameplay");
    }

    public void Level3Pressed()
    {
        LevelManager.Instance.level = 3;
        SceneManager.LoadScene("Gameplay");
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
