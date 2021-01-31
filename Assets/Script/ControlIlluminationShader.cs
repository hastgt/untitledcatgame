using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;
using UnityEngine.UI;

public class ControlIlluminationShader : MonoBehaviour
{
    public static ControlIlluminationShader Instance
    {
        get;
        private set;
    }

    public float cameraZOffset;
    public GameObject undistortedLins;

    private GameObject cloneUndistortedLins;
    private Camera _mCamera;
    private Vector3 mousePos, smoothPoint;
    private Ray ray;
    private RaycastHit hit;
    public UIcountingSouls uiCounting;
    
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, uiCounting.soulsLayer))
            {
                if (hit.collider.name == "soulPrefabMice")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[3].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[3];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
                if (hit.collider.name == "soulPrefabCave")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[0].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[0];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
                if (hit.collider.name == "soulPrefabBlanket")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[2].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[2];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
                if (hit.collider.name == "soulPrefabWallpaper")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[4].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[4];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
                if (hit.collider.name == "soulPrefabTop")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[5].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[5];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
                if (hit.collider.name == "soulPrefabWindow")
                {
                    uiCounting.FoundTheSoul(hit);
                    uiCounting.mementoText[1].gameObject.SetActive(true);
                    uiCounting.textBox.gameObject.SetActive(true);
                    TMP_Text text = uiCounting.mementoText[1];
                    Image image = uiCounting.textBox;
                    StartCoroutine(DisableThings(text, image));
                }
            }
            SpawnUndistorted(GetMouseOnScreenPosition());
        }
    }

    private IEnumerator DisableThings(TMP_Text text, Image image)
    {
        yield return new WaitForSeconds(6);
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }

    public Vector3 GetMouseOnScreenPosition()
    {
        // pixel coordinates (x, y)
        Vector3 touchPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZOffset);

        return _mCamera.ScreenToWorldPoint(touchPoint);
    }
    public void UndistortedOnMouseClick()
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
    public void SpawnUndistorted(Vector3 pos)
    {
        pos = new Vector3(GetMouseOnScreenPosition().x,
            GetMouseOnScreenPosition().y, GetMouseOnScreenPosition().z - 2);

        cloneUndistortedLins = Instantiate(undistortedLins, pos, undistortedLins.transform.rotation);
    }
}
