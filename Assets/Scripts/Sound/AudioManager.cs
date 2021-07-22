using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(AudioSource))]
public class AudioManager : Singleton
{

    public static UnityEvent<PoolableAudioSource>  onClipFinishEvent;
    public static UnityEvent <string> onPlaySoundRequest;
    public static UnityEvent <string> onPlayBGMRequest;

    public static UnityEvent<bool> onSoundSettingChangeEvent;
    public static UnityEvent<bool> onBGMSettingChangeEvent;

    [SerializeField] AudioSource mAudioSourceSample;
    [SerializeField] AudioClip[] mAudioSamples;
    Dictionary <string, AudioClip> mAudioSampleDictionary;
    ObjectPool mAudioObjectPool;

    AudioSource mBgmAudioSource;


    bool mSoundOn;
    bool mBGMOn;
    
    


    private void OnEnable()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        mBgmAudioSource = GetComponent<AudioSource>();
        MakeAudioSourceHashMap();
        mAudioObjectPool = new ObjectPool ();
        mAudioObjectPool.SetParentTransform(transform);
        mAudioObjectPool.Init(mAudioSourceSample.gameObject.GetComponent<PoolableObject>(), 10);

        onPlaySoundRequest.AddListener (OnPlaySoundRequestHandler);
        onPlayBGMRequest.AddListener (PlayBackgroundMusic);

        onBGMSettingChangeEvent.AddListener(OnBGMSettingChangeEventHandler);
        onSoundSettingChangeEvent.AddListener(OnSoundSettingChangeEventHandler);
    

        OnSoundSettingChangeEventHandler (PlayerPrefs.GetInt("soundOn", 1) > 0);
        OnBGMSettingChangeEventHandler (PlayerPrefs.GetInt("bgmOn", 1) > 0 );

    }


    private void OnDisable()
    {
        onPlaySoundRequest.RemoveListener(OnPlaySoundRequestHandler);

        onBGMSettingChangeEvent.RemoveListener(OnBGMSettingChangeEventHandler);
        onSoundSettingChangeEvent.RemoveListener(OnSoundSettingChangeEventHandler);
        onPlayBGMRequest.RemoveListener (PlayBackgroundMusic);
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

    public void PlayBackgroundMusic(string pFileName)
    {
        Debug.Log (pFileName);
        try
        {

            if (mBgmAudioSource == null)
            {

               
           
            }
            try
            {
                if (pFileName == null)
                {
                    return;
                }

                

                if ( mBgmAudioSource.clip != null && mBgmAudioSource.clip.name != pFileName)
                {
                    if (mBgmAudioSource.isPlaying)
                    {
                        mBgmAudioSource.Stop();
                    }
                }
                try
                {
                    mBgmAudioSource.clip = mAudioSampleDictionary[pFileName];
                    if (mBGMOn == true)
                    {
                        mBgmAudioSource.Play();
                    }
                }
                catch (KeyNotFoundException)
                {
                    Debug.LogError (string.Format("There's no audio sample with name {0}.", pFileName));
                }
            }
            catch (System.NullReferenceException)
            {

            }
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("AudioSource Prefab does not have component AudioSource.");
        }
    }

    void OnBGMSettingChangeEventHandler(bool value)
    {
        if (value == true)
        {
            mBgmAudioSource.Play();
            
        }
        else
        {
            mBgmAudioSource.Pause();
        }

        mBGMOn = value;
        PlayerPrefs.SetInt("bgmOn", mBGMOn ? 1 : 0);


    }

    void OnSoundSettingChangeEventHandler (bool value)
    {
        Debug.Log ("received sound setting change " + value);
        if (value == true)
        {
            onPlaySoundRequest.AddListener(OnPlaySoundRequestHandler);
        }
        else
        {
            onPlaySoundRequest.RemoveListener (OnPlaySoundRequestHandler);
        }
        mSoundOn = value;
        PlayerPrefs.SetInt("soundOn", mSoundOn ? 1 : 0);

        
    }
}
