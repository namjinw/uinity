using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;
    void Start()
    {
        
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

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;
        transform.position += move;

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
