using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFading : MonoBehaviour
{
    private bool isCatFadding;
    private float _fading;
    public SpriteRenderer cat;

    // Update is called once per frame
    void LateUpdate()
    {
        _fading -= 0.0000099f;
        cat.color += new Color(0, 0, 0, _fading);
    }
   
}
