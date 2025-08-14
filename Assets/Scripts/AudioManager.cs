using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // singleton
    public static AudioManager Instance;

    // audionya nyala apa mati?
    private bool isAudioOn = true;

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

        // set up audionya
        AudioSetup();
    }

    private void AudioSetup()
    {
        // ambil dulu pengaturan audio sebelumnya
        isAudioOn = PlayerPrefs.GetInt("Audio", 1) == 1;

        // set volumenya
        AudioListener.volume = isAudioOn ? 1 : 0;
    }
}
