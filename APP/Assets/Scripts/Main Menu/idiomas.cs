using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class NewBehaviourScript : MonoBehaviour
{
    private bool _activate = false;
    void Start()
    {
        int ID = PlayerPrefs.GetInt("LocalKey", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localeID)
    {
        if (_activate)
        {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }

    private IEnumerator SetLocale(int localeID)
    {
        _activate = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleKey", localeID);
        _activate = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
