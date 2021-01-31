using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFading : MonoBehaviour
{
    private bool isCatFadding;
    private float _fading;
    public SpriteRenderer cat;

    // Start is called before the first frame update
    void Awake()
    {
        //Invoke("IsCatFadding", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCatFadding)
        {
            _fading -= 0.00001f;
            cat.color += new Color(0, 0, 0, _fading);
        }
    }
    private void IsCatFadding()
    {
        isCatFadding = true;
    }
}
