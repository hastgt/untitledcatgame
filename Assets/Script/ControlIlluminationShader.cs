using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlIlluminationShader : MonoBehaviour
{
    public float cameraZOffset;
    public GameObject undistortedLins;

    private GameObject cloneUndistortedLins;
    private Camera _mCamera;
    private Vector3 mousePos, smoothPoint;
    private Ray ray;
    private RaycastHit hit;
    
    [Range(0, 10)]
    [SerializeField] private float radius, softness;
    [Range(0, 100)]
    [SerializeField] private float smoothSpeed;

    private static readonly int GlobaLmaskPosition = Shader.PropertyToID("GLOBALmask_Position");
    private static readonly int GlobaLmaskSoftness = Shader.PropertyToID("GLOBALmask_Softness");
    private static readonly int GlobaLmaskRadius = Shader.PropertyToID("GLOBALmask_Radius");

    
    private void Awake()
    {
        _mCamera = Camera.main;
    }
    private void Update()
    {
        UndistortedOnMouseClick();

        if (Input.GetMouseButton(0))
        {
            SpawnUndistorted();
        }
    }
    public Vector3 GetMouseOnScreenPosition()
    {
        // pixel coordinates (x, y)
        Vector3 touchPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZOffset);

        return _mCamera.ScreenToWorldPoint(touchPoint);
    }
    private void UndistortedOnMouseClick()
    {
        Vector3 neededPos = GetMouseOnScreenPosition();

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        ray = _mCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit))
        {
            smoothPoint = Vector3.MoveTowards(smoothPoint, hit.point, smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(neededPos.x, neededPos.y, neededPos.z, 0);
            Shader.SetGlobalVector(GlobaLmaskPosition, pos);
        }

        Shader.SetGlobalFloat(GlobaLmaskRadius, radius);
        Shader.SetGlobalFloat(GlobaLmaskSoftness, softness);
    }
    public void SpawnUndistorted()
    {
        cloneUndistortedLins = Instantiate(undistortedLins, new Vector3(GetMouseOnScreenPosition().x, 
            GetMouseOnScreenPosition().y, GetMouseOnScreenPosition().z - 2), undistortedLins.transform.rotation);
        Destroy(cloneUndistortedLins, 3.0f);
    }
}
