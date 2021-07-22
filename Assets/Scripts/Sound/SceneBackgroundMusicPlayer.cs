using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] string bgmName;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.onPlayBGMRequest.Invoke(bgmName);
    }
}
