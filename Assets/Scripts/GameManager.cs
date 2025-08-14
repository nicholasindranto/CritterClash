using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager Instance;

    // reference ke karakternya
    public GameObject player;

    // reference ke score text nya
    public TMP_Text scoreText;

    // scorenya
    public int scoreValue = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // memastikan bahwa player udah bener bener di assign
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        // pastikan hanya dijalankan pas di scene gameplay
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            // memastikan ketika game di re play semuanya tetap terassign
            // if and only if dia null alias missing
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }

            if (scoreText == null)
            {
                scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
                UpdateScoreText();
            }
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
