using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggleController : MonoBehaviour
{
    // reference ke togglenya
    public Toggle audioToggle;

    // apakah audionya nyala atau nggak?
    private bool isAudioOn = true;

    // reference ke text on off nya
    public Text onOff;

    private void Start()
    {
        // ambil dulu pengaturan audio sebelumnya
        isAudioOn = PlayerPrefs.GetInt("Audio", 1) == 1;

        // set dulu, kalau sebelumnya on, maka on in, kalau kaga, maka matiin volumenya
        AudioListener.volume = isAudioOn ? 1 : 0;

        // set ke audioToggle nya, on atau off
        audioToggle.isOn = isAudioOn;

        // listener biar dia bisa berubah valuenya, on atau off
        audioToggle.onValueChanged.AddListener(delegate { ToggleAudio(audioToggle.isOn); });

        // set dulu tulisan dari on off nya
        onOff.text = isAudioOn ? "On" : "Off";
    }

    public void ToggleAudio(bool isOn) // biar bisa nyimpen ke player prefs
    {
        isAudioOn = isOn;
        AudioListener.volume = isAudioOn ? 1 : 0;
        PlayerPrefs.SetInt("Audio", isAudioOn ? 1 : 0);
        PlayerPrefs.Save();

        onOff.text = isAudioOn ? "On" : "Off";
    }
}
