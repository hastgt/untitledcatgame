using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DistortOnMouse : MonoBehaviour
{
    private Camera camera;
    private Vector3 mousePos, smoothPoint;
    private Ray ray;
    private RaycastHit hit;
    
    [Range(0, 10)]
    [SerializeField] private float radius, softness;
    [Range(0, 30)]
    [SerializeField] private float smoothSpeed;

    private static readonly int GlobaLmaskPosition = Shader.PropertyToID("GLOBALmask_Position");
    private static readonly int GlobaLmaskSoftness = Shader.PropertyToID("GLOBALmask_Softness");
    private static readonly int GlobaLmaskRadius = Shader.PropertyToID("GLOBALmask_Radius");

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        DistortOnMouseClick();
    }

    private void DistortOnMouseClick()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        ray = camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit))
        {
            smoothPoint = Vector3.MoveTowards(smoothPoint, hit.point, smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(smoothPoint.x, smoothPoint.y, smoothPoint.z, 0);
            Shader.SetGlobalVector(GlobaLmaskPosition, pos);
        }

        Shader.SetGlobalFloat(GlobaLmaskRadius, radius);
        Shader.SetGlobalFloat(GlobaLmaskSoftness, softness);
    }
}
