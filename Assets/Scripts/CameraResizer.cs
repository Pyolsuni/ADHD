using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera : MonoBehaviour
{

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        Debug.Log(camera);
        UpdateCameraSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCameraSize()
    {
        float targetAspect = 16.0f / 9.0f;
        Debug.Log("targetAspect: " + targetAspect);
    }
}
