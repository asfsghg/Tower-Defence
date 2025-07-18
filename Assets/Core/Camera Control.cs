using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private Camera cam;
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

    }
}