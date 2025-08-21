using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;
    public float speed = 5f;
    public float jump = 6f;
    public bool isGrounded = true;
    private Renderer Renderer;
    private Color ori;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
        ori = Renderer.material.color;
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

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("objects"))
        {
            Renderer.material.color = Color.yellow;
            Debug.Log("立盟沁促!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("objects"))
        {
            Renderer.material.color = ori;
            Debug.Log("立盟场车促!");
        }
    }
}
