using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowScript : MonoBehaviour
{
    [FMODUnity.EventRef] public string sfxEventPath;
    private bool playSFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playSFX)
        {
            playSFX = true;
            AudioManager.Instance.PlaySFX(sfxEventPath);
            StartCoroutine(PlayedSFX());
        }
    }

    private IEnumerator PlayedSFX()
    {
        yield return new WaitForSeconds(1);
        playSFX = false;
    }
}
