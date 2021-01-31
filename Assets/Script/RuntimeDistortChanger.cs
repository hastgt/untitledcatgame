using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeDistortChanger : MonoBehaviour
{
    public Material distortion;
    public float distortAmount;
    public float timesDistortion;

    private float _distortionAmount;
    private float _normalMapOffset;
    private bool _hardcoded;
    private static readonly int DistortionAmount = Shader.PropertyToID("_DistortionAmount");
    private static readonly int DistortionGuide = Shader.PropertyToID("_DistortionGuide_ST");

    private void Start()
    {
        _distortionAmount = -3f;
        InvokeRepeating(nameof(AnimateDistortion), 0f, timesDistortion);
    }

    void FixedUpdate()
    {
        if (_hardcoded)
        {
            _distortionAmount += distortAmount;
            _normalMapOffset += 0.001f;
        }
        else if (!_hardcoded)
        {
            _distortionAmount -= distortAmount;
            _normalMapOffset -= 0.001f;
        }

        distortion.SetFloat(DistortionAmount, _distortionAmount);
        Vector4 offVec = new Vector4(_normalMapOffset, 0, 0, 0);
        //distortion.SetVector(DistortionGuide, offVec);
    }

    private void AnimateDistortion()
    {
        if (_hardcoded)
        {
            _hardcoded = false;
        }
        else if (!_hardcoded)
        {
            _hardcoded = true;
        }
        Debug.Log("every 3 seconds");
    }
}
