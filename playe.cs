using UnityEngine;

public class playe : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;
    public float speed = 10f;
    private bool isGround = true;
    public float jump = 3f;
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

        if (Input.GetKey(KeyCode.Space) && isGround) {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGround = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(move);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
