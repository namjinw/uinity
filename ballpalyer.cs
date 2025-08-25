using UnityEngine;

public class ballpalyer : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    private bool isground = true;
    private Rigidbody rb;
    private Vector3 move;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) { moveZ += 1f; }
        if (Input.GetKey(KeyCode.S)) { moveZ -= 1f; }
        if (Input.GetKey(KeyCode.D)) { moveX += 1f; }
        if (Input.GetKey(KeyCode.A)) { moveX -= 1f; }

        Vector3 movedirection = new Vector3(moveX, 0, moveZ).normalized; //¿ùµåÁÂÇ¥
        movedirection = transform.TransformDirection(movedirection); // ·ÎÄÃÁÂÇ¥
        move = movedirection * speed;

        if (Input.GetKey (KeyCode.Space) && isground)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isground = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(move);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isground = true;
        }
    }
}
