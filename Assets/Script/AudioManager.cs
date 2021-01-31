using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef] public string musicEventPath;
    [FMODUnity.EventRef] public string sfxEventPath;
    private static FMOD.Studio.EventInstance music;
    private static FMOD.Studio.EventInstance sfx;

    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance(musicEventPath);
        music.start();
        music.release();

        sfx = FMODUnity.RuntimeManager.CreateInstance(sfxEventPath);
    }
    private void PlaySFX(string path)
    {

    }
    private void PlayMusic(string path)
    {

    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        sfx.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
