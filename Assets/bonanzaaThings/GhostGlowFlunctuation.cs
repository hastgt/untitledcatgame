using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class GhostGlowFlunctuation : MonoBehaviour
{
    public float _minValue;
    public float _maxValue;
    public float _frequency;

    public UnityEngine.Experimental.Rendering.Universal.Light2D light;

    private float _offset;
    void Start()
    {
        _offset = Random.Range(_minValue, _maxValue);
        light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float sinWaveAdd = 1.7f;
        float tempIntensity = Mathf.Abs(sinWaveAdd + Mathf.Sin(Time.fixedTime * Mathf.PI * _frequency)) * _offset;
        light.intensity = tempIntensity;
        
    }
}
