using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupLoad : MonoBehaviour
{
    void Start()
    {
        SettingsData settingsData = SaveManager.LoadSettingsData();
    }

}
