using UnityEngine;

public class ballmove : MonoBehaviour
{
    private Rigidbody rb; // 물리 개체
    private Vector3 move; // move 전역 변수로 선언
    public float speed = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) { moveZ += 1f; }
        if (Input.GetKey(KeyCode.S)) { moveZ -= 1f; }
        if (Input.GetKey(KeyCode.D)) { moveX += 1f; }
        if (Input.GetKey(KeyCode.A)) { moveX -= 1f; }

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        move = moveDirection * speed;
    }

    void FixedUpdate()
    {
        rb.AddForce(move);
    }
}
