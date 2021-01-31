using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef] public string musicEventPath;
    [FMODUnity.EventRef] public string sfxEventPath;
    private static FMOD.Studio.EventInstance music;
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
    }

    // Start is called before the first frame update
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

    private void PlayMusic(string path)
    {

    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
