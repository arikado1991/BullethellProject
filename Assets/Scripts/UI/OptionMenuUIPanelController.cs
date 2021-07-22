using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class OptionMenuUIPanelController : UIPanelController
{
    [SerializeField] Toggle soundToggle;
    [SerializeField] Toggle bgmToggle;

    bool soundSettingOn;
    bool bgmSettingOn;

    private void OnEnable()
    {
        soundToggle.isOn = PlayerPrefs.GetInt("soundOn", 1) > 0;
        bgmToggle.isOn = PlayerPrefs.GetInt("bgmOn", 1) > 0;
    }
    // Start is called before the first frame update
    public void OnSoundToggle(bool toggleValue)
    {
        soundSettingOn = toggleValue;
        AudioManager.onSoundSettingChangeEvent.Invoke(soundSettingOn);

    }

    public void OnBGMToggle (bool toggleValue)
    {
        bgmSettingOn = toggleValue;
        AudioManager.onBGMSettingChangeEvent.Invoke(bgmSettingOn);
    }
}
