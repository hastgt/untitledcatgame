using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef] public string musicEventPath;
    [FMODUnity.EventRef] public string sfxEventPath;
    private static FMOD.Studio.EventInstance music;

    private FMOD.Studio.Bus mainBus;

    public static AudioManager Instance
    {
        get;
        private set;
    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        mainBus = FMODUnity.RuntimeManager.GetBus("bus:/Main");
    }

    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance(musicEventPath);
        music.start();
        music.release();
    }

    public void PlaySFX(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxEventPath);
    }

    public void MuteAudio()
    {
        mainBus.setVolume(-80);
    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
