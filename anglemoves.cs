using UnityEngine;

public class anglemove : MonoBehaviour
{
    public Transform player;
    public float mousemove = 200f;
    public Vector3 offset = new Vector3(0, 3.5f, -5f);

    float Xrotation = 0f;
    float Yrotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousemove * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousemove * Time.deltaTime;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -40f, 40f);

        Yrotation += mouseX;

        Quaternion rotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        transform.position = player.position + rotation * offset;

        transform.LookAt(player);
    }
}
