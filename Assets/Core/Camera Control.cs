using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float scrollSpeed = 5f;
    private Camera cam;
    public float edgeScrollSize = 10f; 
    public float minY = 10f;
    public float maxY = 80f;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        cam.transform.Translate(Vector3.right * horizontal);
        cam.transform.Translate(Vector3.forward * vertical);

        
        
        float scroll = Input.GetAxis("Mouse ScrollWheel"); 
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        
        if (Input.mousePosition.y >= Screen.height - edgeScrollSize)
            pos.z += moveSpeed * Time.deltaTime;
        if (Input.mousePosition.y <= edgeScrollSize)
            pos.z -= moveSpeed * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width - edgeScrollSize)
            pos.x += moveSpeed * Time.deltaTime;
        if (Input.mousePosition.x <= edgeScrollSize)
            pos.x -= moveSpeed * Time.deltaTime;
    }
}