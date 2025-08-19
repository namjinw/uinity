using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 10f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1;
        if (Input.GetKey(KeyCode.D)) moveX += 1;
        if (Input.GetKey(KeyCode.A)) moveX -= 1;

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 move = moveDirection * speed * Time.deltaTime;
        transform.position += move;

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        float rawSpeed = move.magnitude / Time.deltaTime;
        animator.SetFloat("speed", rawSpeed);
        animator.SetBool("isRunning", rawSpeed > 0.1f);
    }
}
