using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))] 
public class PoolableAudioSource : PoolableObject
{
    AudioSource mAudioSource;

    void Start ()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (mAudioSource.isPlaying != true)
        {
            gameObject.SetActive(false);
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        AudioManager.onClipFinishEvent.Invoke (this);
    }
}
