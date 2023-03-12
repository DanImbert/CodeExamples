using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleDropdown : MonoBehaviour
{
    public TMP_Dropdown Languageselect;
    private void Start()
    {
        Languageselect = GetComponent<TMP_Dropdown>();
        //ChangeLanguage(Languageselect);
    }
    public void ChangeLanguage(TMP_Dropdown drop)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[Languageselect.value];       

    }
}