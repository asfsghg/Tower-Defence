using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float edgeScrollSize = 10f; 
    public float zoomSpeed = 10f;
    public float minY = 10f;
    public float maxY = 100f;

    void Update()
    {
        Vector3 pos = transform.position;
       
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            pos.z += moveSpeed * Time.deltaTime;
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            pos.z -= moveSpeed * Time.deltaTime;
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            pos.x += moveSpeed * Time.deltaTime;
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            pos.x -= moveSpeed * Time.deltaTime;

       
        if (Input.mousePosition.y >= Screen.height - edgeScrollSize)
            pos.z += moveSpeed * Time.deltaTime;
        if (Input.mousePosition.y <= edgeScrollSize)
            pos.z -= moveSpeed * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width - edgeScrollSize)
            pos.x += moveSpeed * Time.deltaTime;
        if (Input.mousePosition.x <= edgeScrollSize)
            pos.x -= moveSpeed * Time.deltaTime;

        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * zoomSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
