using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ġ
    private Vector3 offset = new Vector3(0f, 4f, -5f); // ī�޶� �⺻ ��ġ
    public float mousemove = 200f; // ���콺 ����
    private float Xrotation = 0f; // Xȸ��
    private float Yrotation = 0f; // Yȸ��
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // ���콺 ��ױ�
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousemove * Time.deltaTime; // X(����)
        float mouseY = Input.GetAxis("Mouse Y") * mousemove * Time.deltaTime; // Y(�¿�)

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -40f, 40f); // ��������

        Yrotation += mouseX;

        Quaternion rotation = Quaternion.Euler(Xrotation, Yrotation, 0); // ȸ��
        transform.position = player.position + rotation * offset; // ī�޶� ��ġ = �÷��̾� ��ġ + ȸ�� * ī�޶� ��ġ
        transform.LookAt(player.position + Vector3.up * 1f);  // �÷��̾� �ٶ󺸰�

        player.rotation = Quaternion.Euler(0, Yrotation, 0); // �÷��̾� ȸ��
    }
}
