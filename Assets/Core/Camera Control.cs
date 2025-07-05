using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        cam.transform.Translate(Vector3.right * horizontal);
    }
}
