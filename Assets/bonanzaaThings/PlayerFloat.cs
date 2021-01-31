using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    private float randomOffset;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public float amplitude;
    public float frequency;
    void Start()
    {
        randomOffset = Random.Range(0f, 2f);
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
