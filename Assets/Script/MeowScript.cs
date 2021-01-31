using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowScript : MonoBehaviour
{
    [FMODUnity.EventRef] public string sfxEventPath;
    private bool playSFX;
    private Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playSFX)
        {
            playSFX = true;
            AudioManager.Instance.PlaySFX(sfxEventPath);
            StartCoroutine(PlayedSFX());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }
    }

    private IEnumerator PlayedSFX()
    {
        yield return new WaitForSeconds(1);
        playSFX = false;
    }
}
