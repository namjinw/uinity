using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    private Vector3 offset = new Vector3(0f, 4f, -5f); // 카메라 기본 위치
    public float mousemove = 200f; // 마우스 감도
    private float Xrotation = 0f; // X회전
    private float Yrotation = 0f; // Y회전
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // 마우스 잠그기
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousemove * Time.deltaTime; // X(상하)
        float mouseY = Input.GetAxis("Mouse Y") * mousemove * Time.deltaTime; // Y(좌우)

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -40f, 40f); // 범위지정

        Yrotation += mouseX;

        Quaternion rotation = Quaternion.Euler(Xrotation, Yrotation, 0); // 회전
        transform.position = player.position + rotation * offset; // 카메라 위치 = 플레이어 위치 + 회전 * 카메라 위치
        transform.LookAt(player.position + Vector3.up * 1f);  // 플레이어 바라보게

        player.rotation = Quaternion.Euler(0, Yrotation, 0); // 플레이어 회전
    }
}
