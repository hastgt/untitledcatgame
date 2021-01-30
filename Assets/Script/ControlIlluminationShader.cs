using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlIlluminationShader : MonoBehaviour
{
    public Camera camera;
    public Transform player;
    public float cameraZOffset;

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

    // Update is called once per frame
    void Update()
    {
        DistortOnMouseClick();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //    if (hit.collider != null)
        //    {
        //        Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        //    }
        //    else
        //        Debug.Log("nothing");
        //}
    }

    private Vector3 GetMouseOnScreenPosition()
    {
        // pixel coordinates (x, y)
        Vector3 touchPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZOffset);

        // z coordinate of game object on screen

        return camera.ScreenToWorldPoint(touchPoint);
    }

    private void DistortOnMouseClick()
    {
        Vector3 neededPos = GetMouseOnScreenPosition();

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        ray = camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit))
        {
            smoothPoint = Vector3.MoveTowards(smoothPoint, hit.point, smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(neededPos.x, neededPos.y, neededPos.z, 0);
            Shader.SetGlobalVector(GlobaLmaskPosition, pos);
        }

        Shader.SetGlobalFloat(GlobaLmaskRadius, radius);
        Shader.SetGlobalFloat(GlobaLmaskSoftness, softness);
    }
}
