using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageManager : MonoBehaviour
{
    // singleton
    public static LanguageManager Instance;

    // dictionary buat kata yang mau diterjemahkan
    private Dictionary<string, Dictionary<string, string>> localization = new Dictionary<string, Dictionary<string, string>>();
    private string currentLanguage; // lang saat ini

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

        // langsung terjemahkan
        InitializeLocalization();

        // ambil dari playerprefs, ddefault nya english
        currentLanguage = PlayerPrefs.GetString("Language", "English");

        Debug.Log("lang saat ini : " + currentLanguage);

        // ketika scenenya berubah maka update UI nya
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void InitializeLocalization()
    {
        // kita bikin data bahasanya
        localization["English"] = new Dictionary<string, string>
        {
            {"play", "Play"},
            {"settings", "Settings"},
            {"quit", "Quit"},
            {"audio", "Audio"},
            {"language", "Language"},
            {"back", "Back"},
            {"pilih", "Choose Level"},
            {"how", "How To Play"},
            {"on", "On"},
            {"off", "Off"},
            {"move", "Move"},
            {"attack", "Attack"},
            {"rshift", "Right Shift"},
            {"moveHoriz", "A, D, Left Arrow, Right Arrow"},
        };

        localization["Indonesia"] = new Dictionary<string, string>
        {
            {"play", "Main"},
            {"settings", "Pengaturan"},
            {"quit", "Keluar"},
            {"audio", "Suara"},
            {"language", "Bahasa"},
            {"back", "Kembali"},
            {"pilih", "Pilih Level"},
            {"how", "Cara Main"},
            {"on", "Nyala"},
            {"off", "Mati"},
            {"move", "Gerak"},
            {"attack", "Serang"},
            {"rshift", "Shift Kanan"},
            {"moveHoriz", "A, D, Panah Kiri, Panah Kanan"},
        };
    }

    public void SetLanguage(string language) // ubah bahasa saat ini dan simpen di player prefs
    {
        Debug.Log("di SetLanguage(string language), language = " + language);
        if (localization.ContainsKey(language))
        {
            currentLanguage = language;
            PlayerPrefs.SetString("Language", currentLanguage);
            PlayerPrefs.Save();
            UpdateUI();
        }
    }

    private void UpdateUI() // ambil semua UI text yang punya localizedtext dan ubah textnya
    {
        LocalizedText[] texts = FindObjectsOfType<LocalizedText>();
        Debug.Log("texts banyaknya adalah = " + texts.Length);
        foreach (LocalizedText text in texts)
        {
            text.UpdateText();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUI(); // update UI nya setelah scene diload
    }

    public string GetLocalizedValue(string key)
    {
        if (localization[currentLanguage].ContainsKey(key))
        {
            return localization[currentLanguage][key];
        }
        return key;
    }
}
