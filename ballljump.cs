using UnityEngine;

public class ballljump : MonoBehaviour
{
    private Rigidbody rb; // ���� �浹 ������Ʈ
    private Vector3 move; // �̵��Ÿ� ����
    public float speed = 5f; // �̵� �Ÿ�
    public float jump_height = 7.5f; // ���� ����
    private bool isGround = true; // ���� ����ִ��� ������ ����
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ������ٵ� ��������
    }

    void Update() // �� �����Ӱ��� �Լ�
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) { moveZ += 1f; }
        if (Input.GetKey(KeyCode.S)) { moveZ -= 1f; }
        if (Input.GetKey(KeyCode.D)) { moveX += 1f; }
        if (Input.GetKey(KeyCode.A)) { moveX -= 1f; }

        Vector3 moveDirection = new Vector3 (moveX, 0, moveZ).normalized;
        move = moveDirection * speed;

        if (Input.GetKey(KeyCode.Space) && isGround) // �����̽�, ���� ������� ��
        {
            rb.AddForce(Vector3.up * jump_height, ForceMode.Impulse); // AddForce => �� ���ϴ� �Լ�, Vector3.up => Y��ǥ, ForceMode => ���� ����Ǵ� ���, Impulse(��������)
            isGround = false; // ����Ű ������ �ʱ�ȭ ��Ű�� ������
        }
    }

    private void FixedUpdate() // ���� ���� ó�� �Լ�
    {
        rb.AddForce(move);
    }

    private void OnCollisionEnter(Collision collision) // �ɸ��浹 ���� �Լ�
    {
        if (collision.gameObject.CompareTag("Ground"))
        { // collision => �����浹 ���� �ڵ�, gameObject => �浹�� ������Ʈ�� ����, CompareTag => ������Ʈ�� �±� ��������
            isGround = true;
        }
    }
}
