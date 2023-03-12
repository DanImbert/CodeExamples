using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOpener : MonoBehaviour
{

    public GameObject settingsPanel;


    public void OpenSettings()
    {
        Debug.Log("Settings selected");

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);

        }


    }

    public void CloseSettings()
    {
        Debug.Log("Settings closed");

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);

        }

    }
}
