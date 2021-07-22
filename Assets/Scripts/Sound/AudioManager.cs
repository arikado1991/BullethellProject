using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : Singleton
{

    public static UnityEvent<PoolableAudioSource>  onClipFinishEvent;
    public static UnityEvent <string> onPlaySoundRequest;

    [SerializeField] AudioSource mAudioSourceSample;
    [SerializeField] AudioClip[] mAudioSamples;
    Dictionary <string, AudioClip> mAudioSampleDictionary;
    ObjectPool mAudioObjectPool;

    private void OnEnable()
    {
        MakeAudioSourceHashMap();
        mAudioObjectPool = new ObjectPool ();
        mAudioObjectPool.Init(mAudioSourceSample.gameObject.GetComponent<PoolableObject>(), 10);
        onPlaySoundRequest.AddListener (OnPlaySoundRequestHandler);
    //    onClipFinishEvent.AddListener (OnClipFinishHandler);

    }


    private void MakeAudioSourceHashMap ()
    {
        mAudioSampleDictionary = new Dictionary<string, AudioClip>(); 
        foreach (AudioClip  clip  in mAudioSamples)
        {
            mAudioSampleDictionary [clip.name] = clip;
        }
    }

    public void OnPlaySoundRequestHandler (string soundName)
    {
        Play (soundName);
    }

    public bool Play (string soundName, bool loop = false /*, float volume = 1f*/ )
    {
        try
        {
            AudioClip selectedAudioClip;

            try {
                AudioSource selectedAudioSource = mAudioObjectPool.GetObject().GetComponent<AudioSource>();
                selectedAudioClip = mAudioSampleDictionary [soundName];
            
                /*if (loop == true)
                {
                    selectedAudioSource.clip = selectedAudioClip;
                    selectedAudioSource.Play ();    
                }
                else
                {*/
                    selectedAudioSource.PlayOneShot (selectedAudioClip);
                //}
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError (string.Format ("There's no AudioSource component in audio source gameObject."));
                return false;
            }
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError ("Entered audio clip name doesnt exist in Audio Manager audioSamples.\n");
            return false;
        }
        return true;
    }

}
