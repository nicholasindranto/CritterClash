using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameplayController : MonoBehaviour
{
    // reference ke button home sama button restart
    public Button buttonHome;
    public Button buttonRestart;

    // reference ke game win game lose ui sama timer text
    public Canvas gameWinUI;
    public Canvas gameLoseUI;
    public TMP_Text timerText;

    // reference ke final score text
    public TMP_Text finalScoreTextWin;
    public TMP_Text finalScoreTextLose;

    // timernya lagi jalan nggak?
    public bool isCounting = true;

    // reference ke playernya
    public GameObject player;

    private void Start()
    {
        StartCoroutine("StartCountdown");

        Debug.Log("coroutine distart");

        // matiin semua ui game win lose
        gameWinUI.gameObject.SetActive(false);
        gameLoseUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        // if ((isCounting == false) && (SceneManager.GetActiveScene().name == "Gameplay"))
        // {
        //     StartCoroutine("StartCountdown");
        // }
    }

    // home pressed
    public void HomePressed()
    {
        // kita play lagi gamenya
        Time.timeScale = 1.0f;

        // reset score
        GameManager.Instance.scoreValue = 0;

        // kita reset coroutine nya
        StopAllCoroutines();

        Debug.Log("coroutine di stop");

        // balik ke mainmenu
        SceneManager.LoadScene("MainMenu");
    }

    // restart pressed
    public void RestartPressed()
    {
        // kita play lagi gamenya
        Time.timeScale = 1.0f;

        // reset score
        GameManager.Instance.scoreValue = 0;

        // kita stop semua coroutine nya
        StopAllCoroutines();

        Debug.Log("coroutine distop");

        // kita load kembali scene yang sedang aktif saat ini yaitu scene gameplay kita
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator StartCountdown()
    {
        // timer jalan
        isCounting = true;

        Debug.Log("apakah masuk cuy?? = " + isCounting);

        // total wait time = 2 menit = 120 detik
        float waitTime = 120f;

        Debug.Log("apakah masuk? waitTime = " + waitTime);

        while ((waitTime > 0f) && (player != null))
        {
            Debug.Log("apakah masuk countdownnya????????");
            yield return new WaitForSecondsRealtime(1.0f);
            waitTime--;

            // ubah ke menit dan detik
            string minutes = Mathf.Floor(waitTime / 60).ToString("00");
            string seconds = (waitTime % 60).ToString("00");

            // update ke timer ui nya
            UpdateTimerUI(minutes, seconds);
        }

        if (player != null)
        {
            isCounting = false; // matiin timer ketika udah win
            GameWin();
        }
    }

    private void UpdateTimerUI(string minutes, string seconds)
    {
        timerText.text = minutes + ":" + seconds;
    }

    public void GameWin()
    {
        // update final scorenya
        finalScoreTextWin.text = "Your Final Score: " + GameManager.Instance.scoreValue;

        // tampilkan canvas win ui
        gameWinUI.gameObject.SetActive(true);

        // pause gamenya
        Time.timeScale = 0f;
    }

    public void GameLose()
    {
        // update final scorenya
        finalScoreTextLose.text = "Your Final Score: " + GameManager.Instance.scoreValue;

        // tampilkan canvas lose ui
        gameLoseUI.gameObject.SetActive(true);

        // pause gamenya
        Time.timeScale = 0f;
    }
}
