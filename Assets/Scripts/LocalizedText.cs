using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// biar semua teks ui bisa otomatis ke translate

public class LocalizedText : MonoBehaviour
{
    public string key; // key buat teksnya

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (LanguageManager.Instance != null)
        {
            GetComponent<TextMeshProUGUI>().text = LanguageManager.Instance.GetLocalizedValue(key);
        }
    }
}
