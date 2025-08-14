using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageDropdown : MonoBehaviour
{
    // reference ke dropdownnya
    public TMP_Dropdown languageDropdown;

    private void Start()
    {
        // ambil dulu bahasa yang di player prefs
        string savedLanguage = PlayerPrefs.GetString("Language", "English");

        // di set dulu value dari dropdownnya
        languageDropdown.value = savedLanguage == "English" ? 0 : 1;

        // listerner biar bahasanya bisa berubah
        languageDropdown.onValueChanged.AddListener(delegate { ChangeLanguage(languageDropdown.value); });
    }

    public void ChangeLanguage(int index)
    {
        Debug.Log("masuk ke dropdownnya, index = " + index);
        string selectedLanguage = index == 0 ? "English" : "Indonesia"; // ambil dulu bahasanya apa
        LanguageManager.Instance.SetLanguage(selectedLanguage); // set di player prefs
    }
}
